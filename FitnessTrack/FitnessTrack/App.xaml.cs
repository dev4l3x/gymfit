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

            MainPage = new NavigationPage(new RoutinePage())
            {
                BarBackgroundColor = Color.White,
                BarTextColor = (Color)App.Current.Resources["Dark"]
            };
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
