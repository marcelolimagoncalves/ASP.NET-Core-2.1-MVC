using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers
{
    [Authorize]
    public class TarefasController : Controller
    {
        ITarefaItemService _tarefaService;
        private readonly UserManager<IdentityUser> _userManager;
        public TarefasController(ITarefaItemService tarefaService, UserManager<IdentityUser> userManager)
        {
            _tarefaService = tarefaService;
            _userManager = userManager;
        }

        // lista de tarefas
        public async Task<IActionResult> Index(bool? criterio)
        {
            // Obter os dados da tarefa
            //TempTarefaItemService servico = new TempTarefaItemService();
            //var tarefas = servico.GetItemAsync();

            var currentUser = await _userManager.GetUserAsync(User);
            if(currentUser == null)
                return Challenge();

            var tarefas = await _tarefaService.GetItemAsync(criterio, currentUser);

            var model = new TarefaViewModel();
            {
                model.TarefaItens = tarefas;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AdicionarItemTarefa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItemTarefa([Bind("Id,EstaCompleta,Nome,DataConclusao")]TarefaItem tarefa)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            tarefa.OwnerId = currentUser.Id;

            if(ModelState.IsValid)
            {
                await _tarefaService.AdicionarItem(tarefa);
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var tarefaItem = _tarefaService.GetTarefaById(id);
            if(tarefaItem == null)
            {
                return NotFound();
            }

            return View(tarefaItem);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tarefaService.DeletarItem(id);
            return RedirectToAction(nameof(Index));
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var tarefaItem = _tarefaService.GetTarefaById(id);
            if(tarefaItem == null)
            {
                return NotFound();
            }
            return View(tarefaItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstaCompleta,Nome,DataConclusao")]TarefaItem tarefaItem)
        {
            if(id != tarefaItem.Id)
            {
                return NotFound();
            }

             var currentUser = await _userManager.GetUserAsync(User);

            if(ModelState.IsValid)
            {
                try
                {
                    await _tarefaService.Update(tarefaItem, currentUser);
                }
                catch(DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarefaItem);
        }
    }
}