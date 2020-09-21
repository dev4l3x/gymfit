using FitnessTrack.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RoutinePage();
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
