using GymFit.Models;
using GymFit.ViewModels.Ejercicio;
using Ninject;
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
    public partial class CrearEjercicioPersonalizadoPage : ContentPage
    {
        public CrearEjercicioPersonalizadoPage()
        {
            InitializeComponent();
            chips.ItemsSource = Enum.GetNames(typeof(MUSCULOS));
            chips2.ItemsSource = Enum.GetNames(typeof(MUSCULOS));
            ViewModel = App.kernel.Get<CrearEjercicioPesonalizadoViewModel>();
        }

        public CrearEjercicioPesonalizadoViewModel ViewModel
        {
            get
            {
                return BindingContext as CrearEjercicioPesonalizadoViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        private void principales_SelectionChanged(object sender, Syncfusion.Buttons.XForms.SfChip.SelectionChangedEventArgs e)
        {
            ViewModel.MusculosPrincipalesChangedCommand.Execute(chips.SelectedItems);
        }
        private void secundarios_SelectionChanged(object sender, Syncfusion.Buttons.XForms.SfChip.SelectionChangedEventArgs e)
        {
            ViewModel.MusculosSecundariosChangedCommand.Execute(chips2.SelectedItems);
        }
    }
}