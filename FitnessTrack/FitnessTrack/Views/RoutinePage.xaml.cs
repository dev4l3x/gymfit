using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack.Views
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
            App.Current.MainPage.Navigation.PushAsync(new FitnessTrack.Views.Routines.AddRoutinePage());
        }
    }
}