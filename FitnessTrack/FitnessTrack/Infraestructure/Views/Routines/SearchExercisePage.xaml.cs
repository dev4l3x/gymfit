using System;
using FitnessTrack.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack.Infraestructure.Views.Routines
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchExercisePage : ContentPage
    {
        public SearchExercisePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateExercisePage());
        }
    }
}