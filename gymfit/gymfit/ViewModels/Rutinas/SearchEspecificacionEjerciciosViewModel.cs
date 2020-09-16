using GymFit.Models;
using GymFit.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using GymFit.Services.Interfaces;
using GymFit.Views.Ejercicio;

namespace GymFit.ViewModels.Rutinas
{
    public class SearchEspecificacionEjerciciosViewModel : BaseViewModel
    {

        private bool _isRunning;
        private IEspecificacionEjerciciosService _especificacionEjerciciosService;
        private IPageService _pageService;

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EspecificacionEjercicio> BusquedaEspecificaciones { get; set; }


        public ICommand SearchButtonTappedCommand { get; set; }
        public ICommand OpenDetailExerciseCommand { get; set; }
        public ICommand CrearEjercicioPersonalizadoCommand { get; set; }

        public SearchEspecificacionEjerciciosViewModel(IEspecificacionEjerciciosService especificacionEjerciciosService, IPageService page)
        {
            InitializeCommands();
            BusquedaEspecificaciones = new ObservableCollection<EspecificacionEjercicio>();
            _especificacionEjerciciosService = especificacionEjerciciosService;
            _pageService = page;
            IsRunning = false;
        }

        public void InitializeCommands()
        {
            SearchButtonTappedCommand = new Command<string>((searchText) => SearchEspecificacionesAlimentosByName(searchText));
            OpenDetailExerciseCommand = new Command<EspecificacionEjercicio>((ejercicio) => OpenDetailExercise(ejercicio));
            CrearEjercicioPersonalizadoCommand = new Command(() => CrearEjercicioPersonalizado());
        }

        private async void CrearEjercicioPersonalizado()
        {
            await _pageService.PushAsync(new CrearEjercicioPersonalizadoPage());
        }

        private async void OpenDetailExercise(EspecificacionEjercicio ejercicio)
        {
            await _pageService.PushAsync(new DetalleEjercicioPage(ejercicio));
        }

        public async void SearchEspecificacionesAlimentosByName(string name)
        {
            IsRunning = true;
            var busqueda = await _especificacionEjerciciosService.GetEspecificacionesEjerciciosByName(name);
            BusquedaEspecificaciones.Clear();
            busqueda.ToList().ForEach((ejercicio) => BusquedaEspecificaciones.Add(ejercicio));
            IsRunning = false;
        }
    }
}
