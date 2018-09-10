using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Tarefas.Models;

namespace Tarefas.Services
{
    public interface ITarefaItemService
    {
         Task<IEnumerable<TarefaItem>> GetItemAsync(bool? criterio, IdentityUser User);
         Task<bool> AdicionarItem(TarefaItem novoItem);
         Task<bool> DeletarItem(int? id);
         TarefaItem GetTarefaById(int? id);
         Task Update(TarefaItem item, IdentityUser User);
    }
}