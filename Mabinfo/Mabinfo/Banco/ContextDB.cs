using Mabinfo.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mabinfo.Banco
{
    class ContextDB
    {
        ObservableCollection<Tarefa> tarefas = new ObservableCollection<Tarefa>();
        public ObservableCollection<Tarefa> Tarefas
        {
            get
            {
                return tarefas;
            }
        }

        static private ContextDB _current;
        static public ContextDB Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new ContextDB();
                }

                return _current;
            }

        }

        private ContextDB()
        {


        }

    }
}
