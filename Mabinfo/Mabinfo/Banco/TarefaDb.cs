using Mabinfo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabinfo.Banco
{
    class TarefaDb
    {
        private BancoContext Banco { get; set; }
   
    public TarefaDb()
        {
            Banco = new BancoContext();
        }
       public async Task<List<Tarefa>> PesquisarAsync(DateTime data)
        {
            return Banco.Tarefas.Where(
                a =>
                a.Data.HasValue &&
                a.Data.Value.Day == data.Day).ToList();
        }

        public async Task<bool> CadastrarAsync(Tarefa tarefa)
        {
            Banco.Tarefas.Add(tarefa);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;


        }
        public async Task<bool> AtualizarAsync(Tarefa tarefa)
        {


            Banco.Tarefas.Update(tarefa);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;


        }


        public async Task<bool> ExcluirAsync(int id)
        {
            Tarefa tarefa = await ConsultarAsync(id);
            Banco.Tarefas.Remove(tarefa);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;


        }

        public async Task<Tarefa> ConsultarAsync(int id)
        {
            return await Banco.Tarefas.FindAsync(id);
        }


    }
}
