using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack.Infraestructure.Views.Routines
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRoutinePage : ContentPage
    {
        public AddRoutinePage()
        {
            InitializeComponent();
        }


        protected override bool OnBackButtonPressed()
        {
            if(PageTwo.IsVisible)
            {
                PageTwo.IsVisible = false;
                PageOne.IsVisible = true;
                ContinueButton.IsVisible = true;
                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            PageOne.IsVisible = false;
            PageTwo.IsVisible = true;
            var but = (Button)sender;
            but.IsVisible = false;
        }
    }
}