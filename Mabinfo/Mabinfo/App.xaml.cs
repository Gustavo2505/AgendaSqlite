using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mabinfo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var pagina = new NavigationPage(
                new XamarinForms.Paginas.Login()
                );

            MainPage = pagina;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
