using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack.Views.Routines
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
                CreateButton.IsVisible = false;
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
            CreateButton.IsVisible = true;
        }
    }
}