using GymFit.Models;
using GymFit.ViewModels.Rutinas;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.Views.Rutinas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchEspecificacionEjerciciosPage : ContentPage
    {
        public SearchEspecificacionEjerciciosPage()
        {
            InitializeComponent();
            ViewModel = App.kernel.Get<SearchEspecificacionEjerciciosViewModel>();
        }

        public SearchEspecificacionEjerciciosViewModel ViewModel
        {
            get
            {
                return BindingContext as SearchEspecificacionEjerciciosViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                ViewModel.OpenDetailExerciseCommand.Execute(e.SelectedItem as EspecificacionEjercicio);
                searchList.SelectedItem = null;
            }
        }
    }
}