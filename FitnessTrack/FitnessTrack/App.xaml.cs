using FitnessTrack.Views;
using Plugin.SharedTransitions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack
{
    public partial class App : Application
    {

        private NavigationPage _navigation;
        public App()
        {
            InitializeComponent();

            _navigation = new SharedTransitionNavigationPage(new RoutinePage())
            {
                BarBackgroundColor = (Color)App.Current.Resources["Background"],
                BarTextColor = (Color)App.Current.Resources["Dark"],
                
            };


            MainPage = _navigation;
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
