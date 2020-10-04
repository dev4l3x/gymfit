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
                BarBackgroundColor = Color.Transparent,
                BarTextColor = (Color)App.Current.Resources["Dark"],
                
            };

            _navigation.Pushed += Navigation_Pushed;
            _navigation.Popped += Navigation_Popped;

            MainPage = _navigation;
        }

        private void Navigation_Popped(object sender, NavigationEventArgs e)
        {
            if(_navigation.Navigation.NavigationStack.Count == 0)
            {
                _navigation.BarBackgroundColor = Color.White;
            }
            
        }

        private void Navigation_Pushed(object sender, NavigationEventArgs e)
        {
            _navigation.BarBackgroundColor = Color.Transparent;
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
