using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Tarefas.Models;

namespace Tarefas.Services
{
    public class TempTarefaItemService : ITarefaItemService
    {
        public Task<bool> AdicionarItem(TarefaItem novoItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarItem(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TarefaItem>> GetItemAsync()
        {
            //Retorna um array de itens de tarefa
            IEnumerable<TarefaItem> itens = new[]
            {
                new TarefaItem
                {
                    Nome = "Aprender ASP.NET Core 2.0",
                    EstaCompleta = false,
                    DataConclusao = DateTimeOffset.Now.AddDays(30)
                },
                new TarefaItem
                {
                    Nome = "Criar aplicações Web",
                    EstaCompleta = false,
                    DataConclusao = DateTimeOffset.Now.AddDays(60)
                }
            };
            return Task.FromResult(itens);
        }

        public Task<IEnumerable<TarefaItem>> GetItemAsync(bool? criterio)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TarefaItem>> GetItemAsync(bool? criterio, IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public TarefaItem GetTarefaById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TarefaItem item)
        {
            throw new NotImplementedException();
        }

        public Task Update(TarefaItem item, IdentityUser User)
        {
            throw new NotImplementedException();
        }
    }
}