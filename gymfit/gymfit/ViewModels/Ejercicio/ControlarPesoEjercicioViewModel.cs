using GymFit.Services.Interfaces;
using GymFit.Views.Ejercicio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymFit.ViewModels.Ejercicio
{
    using System.Collections.ObjectModel;
    using Models;

    public class ControlarPesoEjercicioViewModel : BaseViewModel
    {

        private IPageService _pageService;

        private Models.Ejercicio _ejercicio;
        public Models.Ejercicio Ejercicio
        {
            get
            {
                return _ejercicio;
            }
            set
            {
                _ejercicio = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Registro> Registros { get; set; }

        public ICommand AddRegistroEjercicioCommand { get; set; }

        public ControlarPesoEjercicioViewModel(Models.Ejercicio ejercicio, IPageService pageService)
        {
            InitializeCommands();
            Ejercicio = ejercicio;
            _pageService = pageService;
            MessagingCenter.Subscribe<AddControlEjercicioViewModel, Registro>(this, Events.REGISTRO_ADDED, OnRegistroAdded);
            Registros = new ObservableCollection<Registro>();
            Initialize();
        }

        private void OnRegistroAdded(AddControlEjercicioViewModel sender, Registro registro)
        {
            Registros.Add(registro);
            Ejercicio.Registros.Add(registro);
        }

        private void Initialize()
        {
            if (Ejercicio.Registros != null)
            {
                foreach (var registro in Ejercicio.Registros)
                {
                    Registros.Add(registro);
                }
            }
        }

        private void InitializeCommands()
        {
            AddRegistroEjercicioCommand = new Command(() => AddRegistroEjercicio());
        }

        private async void AddRegistroEjercicio()
        {
            await _pageService.PushAsync(new AddControlEjercicioPage(Ejercicio));
        }
    }
}
