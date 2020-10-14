using FitnessTrack.Infraestructure.Views;
using Plugin.SharedTransitions;
using Xamarin.Forms;

namespace FitnessTrack.Infraestructure
{
    public partial class App : Xamarin.Forms.Application
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
