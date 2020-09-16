using GymFit.ExtensionMethods;
using GymFit.Models;
using GymFit.Services.Intefaces;
using GymFit.Services.Interfaces;
using GymFit.ViewModels.Ejercicio;
using GymFit.Views.Rutinas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymFit.ViewModels.Rutinas
{
    public class AddRutinaViewModel : BaseViewModel
    {

        private IPageService _pageService;
        private IRutinasService _rutiansService;

        private string _nombre;
        private string _descripcion;
        private string _numDiasSemana;
        private string _nivel;

        private bool _hasErrorNombre;
        private bool _hasErrorNumDias;


        private int _selectedDayIndex;

        public int SelectedDayIndex
        {
            get
            {
                return _selectedDayIndex;
            }
            set
            {
                _selectedDayIndex = value;
                OnPropertyChanged();
            }
        }



        public ObservableCollection<Models.Ejercicio> EjerciciosRutina { get; set; }
        public List<string> Levels { 
            get
            {
                return Enum.GetNames(typeof(NIVEL)).ToList();
            } 
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
                OnPropertyChanged();
            }
        }
        public string NumDiasSemana
        {
            get
            {
                return _numDiasSemana;
            }
            set
            {
                _numDiasSemana = value;
                OnPropertyChanged();
            }
        }
        public string Nivel
        {
            get
            {
                return _nivel;
            }
            set
            {
                _nivel = value;
                OnPropertyChanged();
            }
        }

        public bool HasErrorNombre
        {
            get
            {
                return _hasErrorNombre;
            }
            set
            {
                _hasErrorNombre = value;
                OnPropertyChanged();
            }
        }
        public bool HasErrorNumDias
        {
            get
            {
                return _hasErrorNumDias;
            }
            set
            {
                _hasErrorNumDias = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchEspecificacionesEjerciciosCommand { get; set; }
        public ICommand DeleteEjercicioCommand { get; set; }
        public ICommand CreateRutinaCommand { get; set; }

        public AddRutinaViewModel(IPageService pageService, IRutinasService rutinas)
        {
            InitializeCommands();
            
            EjerciciosRutina = new ObservableCollection<Models.Ejercicio>();
            _pageService = pageService;
            _rutiansService = rutinas;
            MessagingCenter.Subscribe<DetalleEjercicioViewModel, Models.Ejercicio>(this, Events.ADD_EJERCICIO, OnAddEjercicio);

        }

        public void InitializeCommands()
        {
            SearchEspecificacionesEjerciciosCommand = new Command(() => SearchEspecificacionesEjercicios());
            DeleteEjercicioCommand = new Command<int>((index) => DeleteEjercicio(index));
            CreateRutinaCommand = new Command(() => CreateRutina());
        }

        private async void CreateRutina()
        {
            if(AreValidFields())
            {
                int numDiasSemana = int.Parse(NumDiasSemana);
                var rutina = new Rutina((NIVEL)Enum.Parse(typeof(NIVEL), Nivel), numDiasSemana, Descripcion, Nombre, EjerciciosRutina);
                
                var rutinaCreada = await _rutiansService.AddRutina(rutina);
                if(rutinaCreada != null)
                {
                    rutina.Id = rutinaCreada.Id;
                    MessagingCenter.Send(this, Events.ADD_RUTINA, rutina);
                }
                await _pageService.PopToRootPage();
            }
        }

        private bool AreValidFields()
        {
            var toret = true;
            HasErrorNombre = HasErrorNumDias = false;
            if(string.IsNullOrWhiteSpace(Nombre))
            {
                HasErrorNombre = true;
                toret = false;
            }
            if(string.IsNullOrWhiteSpace(NumDiasSemana))
            {
                HasErrorNumDias = true;
                toret = false;
            }
            if(!toret)
                MessagingCenter.Send(this, Events.ChangeFirstTabOnAddRutina);
            return toret;
        }

        public async void SearchEspecificacionesEjercicios()
        {
            if(string.IsNullOrWhiteSpace(NumDiasSemana) || (int.TryParse(NumDiasSemana, out var numDias) && numDias <= 0))
            {
                await _pageService.DisplayAlert("No hay días", "Introduce el número de días de la rutina para añadir ejercicios", "Ok");
            }
            else
            {
                Dictionary<string, int> dias = new Dictionary<string, int>();
                for (int i = 1; i <= int.Parse(NumDiasSemana); i++)
                {
                    dias.Add($"Día {i}", i);
                }

                var response = await _pageService.DisplayActionSheet("Selecciona el día al que añadir el ejercicio", "Cancelar",
                    dias.Keys.ToArray());

                if (response == "Cancelar")
                {
                    return;
                }

                SelectedDayIndex = dias.TryGetValue(response, out var dia) ? dia : 0;
                _pageService.PushAsync(new SearchEspecificacionEjerciciosPage());
            }
        }

        private void DeleteEjercicio(int index)
        {
            if(index >= 0 && index < EjerciciosRutina.Count)
            {
                EjerciciosRutina.RemoveAt(index);
            }
        }

        public async void OnAddEjercicio(DetalleEjercicioViewModel viewModel, Models.Ejercicio ejercicio)
        {
            ejercicio.IndexDay = SelectedDayIndex;
            EjerciciosRutina.Add(ejercicio);
        }




    }
}
