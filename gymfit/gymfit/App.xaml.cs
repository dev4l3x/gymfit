using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GymFit.Views.Rutinas;
using Ninject;

namespace GymFit
{
    public partial class App : Application
    {

        public static readonly IKernel kernel = new StandardKernel(new NinjectSettings() { LoadExtensions = false }, new CommonModule());

        public App()
        {
            InitializeComponent();

            MainPage = new RutinasPage();
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
