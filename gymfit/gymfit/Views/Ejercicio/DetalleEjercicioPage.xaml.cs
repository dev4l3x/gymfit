using GymFit.Models;
using GymFit.ViewModels.Ejercicio;
using GymFit.ViewModels.Rutinas;
using Ninject;
using Ninject.Parameters;
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
    public partial class DetalleEjercicioPage : ContentPage
    {

        private int _swipeSelectedIndex;

        public DetalleEjercicioPage(EspecificacionEjercicio especificacion)
        {
            InitializeComponent();
            ViewModel = App.kernel.Get<DetalleEjercicioViewModel>(new ConstructorArgument("especificacion", especificacion));
        }

        public DetalleEjercicioViewModel ViewModel
        {
            get
            {
                return BindingContext as DetalleEjercicioViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        private void seriesList_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            _swipeSelectedIndex = e.ItemIndex;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ViewModel.DeleteSerieCommand.Execute(_swipeSelectedIndex);
        }
    }

}