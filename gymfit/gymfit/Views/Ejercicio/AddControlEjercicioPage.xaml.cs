using GymFit.ViewModels.Ejercicio;
using Ninject;
using Ninject.Parameters;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.Views.Ejercicio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddControlEjercicioPage : ContentPage
    {

        private Models.Ejercicio ejercicio;
        public AddControlEjercicioPage(Models.Ejercicio ejercicio)
        {
            InitializeComponent();
            int numSeries = ejercicio.NumSeries;
            ViewModel = App.kernel.Get<AddControlEjercicioViewModel>(new ConstructorArgument("ejercicio", ejercicio));

        }

        public AddControlEjercicioViewModel ViewModel
        {
            get
            {
                return BindingContext as AddControlEjercicioViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}