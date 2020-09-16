using GymFit.Models;
using GymFit.Services.Interfaces;
using GymFit.Views.Ejercicio;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymFit.ViewModels.Rutinas
{
    public class DetalleRutinaViewModel : BaseViewModel
    {

        private IPageService _pageService;

        private Rutina _rutinaActual;

        public Rutina RutinaActual
        {
            get
            {
                return _rutinaActual;
            }
            set
            {
                _rutinaActual = value;
                OnPropertyChanged();
            }
        }

        public ICommand ControlarPesoEjercicioCommand { get; set; }

        public DetalleRutinaViewModel(Rutina rutina, IPageService pageService)
        {
            InitializeCommands();
            RutinaActual = rutina;
            _pageService = pageService;
        }

        private void InitializeCommands()
        {
            ControlarPesoEjercicioCommand = new Command<ItemSelectionChangedEventArgs>((ejercicio) => 
                { if (ejercicio.AddedItems.Count > 0) ControlarPesoEjercicio(ejercicio.AddedItems[0] as Models.Ejercicio); });
        }

        private void ControlarPesoEjercicio(Models.Ejercicio ejercicio)
        {
            _pageService.PushAsync(new ControlarPesoEjercicioPage(ejercicio));
        }
    }
}
