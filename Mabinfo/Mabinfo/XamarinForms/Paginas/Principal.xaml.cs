using Mabinfo.Banco;
using Mabinfo.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mabinfo.XamarinForms.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {



        public Principal()
        {
            InitializeComponent();
            AtualizarCalendario(DateTime.Now);
              Device.BeginInvokeOnMainThread(async () =>
              {
                  CVListaDeTarefas.ItemsSource = ContextDB.Current.Tarefas;
                  CVListaDeTarefas.ItemsSource = await new TarefaDb().PesquisarAsync(DateTime.Now);



      

                
              });



           /* InitializeComponent();
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    CVListaDeTarefas.ItemsSource = await new TarefaDb().PesquisarAsync(DateTime.Now);
                });
            });*/
        }

        bool isWaiting = false;
        private void btnCadastrar(object sender, EventArgs e)
        {
            if (isWaiting) return;

            Navigation.PushModalAsync(new ModalCadastrar());

            isWaiting = true;

            Task.Run(() =>
            {
                Thread.Sleep(2000);
                isWaiting = false;
            });

        }

        private void Abrir(object sender, EventArgs e)
        {

            var evento = (TappedEventArgs)e;
            var tarefa = (Tarefa)evento.Parameter;

            
            //Tarefa clicada = new Tarefa();

            Navigation.PushAsync(new Visualizar(tarefa.Nome, tarefa.Nota, tarefa.HorarioInicial, tarefa.HorarioFinal));
            //Navigation.PushAsync(new Visualizar);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void SwpExcluir(object sender, EventArgs e)
        {
            bool pergunta = await DisplayAlert("Excluir", "Você tem certeza que deseja excluir este item?", "Sim", "Não");

            if (pergunta == true)
            {
                var swp = (SwipeItem)sender;
                Tarefa tarefa = (Tarefa)swp.CommandParameter;
                var excluido = await new TarefaDb().ExcluirAsync(tarefa.Id);

                if (excluido)
                {
                    var t = ContextDB.Current.Tarefas.FirstOrDefault(taa => 
                    taa.Id == tarefa.Id);
                        
                    var idx = ContextDB.Current.Tarefas.IndexOf(tarefa);
                    var aaa = 1;
                    //ContextDB.Current.Tarefas.Remove(tarefa);
                }


            }

        }

        private void AbrirCalendario(object sender, EventArgs e)
        {
            DPCalendario.Focus();
        }

        private void DateSA(object sender, DateChangedEventArgs e)
        {
            AtualizarCalendario(e.NewDate);
            var Dia = e.NewDate;
       
        }

        private void AtualizarCalendario(DateTime data)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
               CVListaDeTarefas.ItemsSource = ContextDB.Current.Tarefas;
                CVListaDeTarefas.ItemsSource = await new TarefaDb().PesquisarAsync(data);



            });




            var idioma = CultureInfo.CurrentCulture;

            dia.Text = data.Day.ToString();
            Mes.Text = data.ToString("MMMM", idioma);
            DiaSemana.Text = data.ToString("dddd", idioma);
        }
    }

    internal class Lista
    {
    }
}
