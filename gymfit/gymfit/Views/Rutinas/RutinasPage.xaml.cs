using GymFit.Models;
using GymFit.ViewModels.Rutinas;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.Views.Rutinas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RutinasPage : ContentPage
    {

        public RutinasPage()
        {
            InitializeComponent();
            ViewModel = App.kernel.Get<RutinasViewModel>();
        }

        public RutinasViewModel ViewModel
        {
            get
            {
                return BindingContext as RutinasViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }


    }
}