using FitnessTrack.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack.Infraestructure.Views.Routines
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExercisesView : ContentView
    {
        public AddExercisesView()
        {
            InitializeComponent();
        }

        private void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SearchExercisePage());
        }
    }
}