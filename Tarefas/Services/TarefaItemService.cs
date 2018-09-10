using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Models;

namespace Tarefas.Services
{
    public class TarefaItemService : ITarefaItemService
    {
        private readonly ApplicationDbContext _contexto;
        public TarefaItemService(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> AdicionarItem(TarefaItem novoItem)
        {
            var tarefa = new TarefaItem
            {
                EstaCompleta = false,
                Nome = novoItem.Nome,
                OwnerId = novoItem.OwnerId,
                DataConclusao = novoItem.DataConclusao
            };

            _contexto.Tarefas.Add(tarefa);
            var resultado = await _contexto.SaveChangesAsync();
            return resultado == 1;
        }

        public async Task<bool> DeletarItem(int? id)
        {
            TarefaItem tarefa = _contexto.Tarefas.Find(id);
            _contexto.Tarefas.Remove(tarefa);
            var resultado = await _contexto.SaveChangesAsync();
            return resultado == 1;
        }

        public async Task<IEnumerable<TarefaItem>> GetItemAsync(bool? criterio, IdentityUser User)
        {
            TarefaItem[] itens;
            if(criterio != null)
            {
                itens = await _contexto.Tarefas
                                .Where(t => t.EstaCompleta == criterio && t.OwnerId == User.Id)
                                .ToArrayAsync();
            }
            else
            {
                itens = await _contexto.Tarefas
                                .Where(t => t.OwnerId == User.Id)
                                .ToArrayAsync();
            }
            
            return itens;
        }

        public TarefaItem GetTarefaById(int? id)
        {
            return _contexto.Tarefas.Find(id);
        }

        public async Task Update(TarefaItem item, IdentityUser User)
        {
            if(item.OwnerId == null)
                item.OwnerId = User.Id;

            if(item == null)
            {
                throw new ArgumentException(nameof(item));
            }

            _contexto.Tarefas.Update(item);
            await _contexto.SaveChangesAsync();
        }
    }
}