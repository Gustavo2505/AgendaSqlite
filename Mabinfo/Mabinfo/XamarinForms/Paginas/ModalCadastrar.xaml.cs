using Mabinfo.Banco;
using Mabinfo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mabinfo.XamarinForms.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalCadastrar : ContentPage
    {
        public ModalCadastrar()
        {
            InitializeComponent();
        }

        private void BtnFecharModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }



        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            var rx = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");

            if (!rx.IsMatch(Nome.Text))
            {
                await DisplayAlert("Erro", "Nome inválido", "OK");
                Nome.Focus();
                return;
            }

            if (!rx.IsMatch(Nota.Text))
            {
                await DisplayAlert("Erro", "Nota inválida", "OK");
                Nota.Focus();
                return;
            }

            Tarefa tarefa = new Tarefa
            {
                Nome = Nome.Text,
                Nota = Nota.Text,
                Data = Data.Date,
                HorarioInicial = HorarioInicial.Time,
                HorarioFinal = HorarioFinal.Time
            };


            await new TarefaDb().CadastrarAsync(tarefa);

            ContextDB.Current.Tarefas.Add(tarefa);

            await DisplayAlert("Sucesso", "Tarefa inserida com sucesso", "OK");
            BtnFecharModal(sender, e);

        }

    }
}
