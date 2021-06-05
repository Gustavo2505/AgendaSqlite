using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mabinfo.XamarinForms.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Visualizar : ContentPage
    {
      public Visualizar ()
        {
            InitializeComponent();
        }
        public Visualizar(string title, string description, TimeSpan? start, TimeSpan? end)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblHoraInicial.Text = $"Hora de início {start.ToString()}";
            lblhoraFinal.Text = $"Hora Fim {end.ToString()}";
            lblNota.Text = $"Nota\n{description}";
        }

        private void BtnVoltar(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}