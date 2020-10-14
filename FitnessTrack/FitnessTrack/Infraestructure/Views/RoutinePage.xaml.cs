using System;
using FitnessTrack.Domain;
using FitnessTrack.Infraestructure.Views.Routines;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack.Infraestructure.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutinePage : ContentPage
    {
        public RoutinePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AddRoutinePage());
        }
    }
}