using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymFit.ViewModels.Ejercicio
{
    using System.Threading.Tasks;
    using Models;
    using Services.Intefaces;
    using Services.Interfaces;

    public class AddControlEjercicioViewModel : BaseViewModel
    {

        private IEjerciciosService _ejerciciosService;
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

        public List<string> Series
        {
            get
            {
                var series = new List<string>();
                for (int i = 1; i <= Ejercicio.NumSeries; i++)
                {
                    series.Add("Serie " + i);
                }

                return series;
            }
        }



        private int _serieSeleccionada;
        public int SerieSeleccionada
        {
            get
            {
                return _serieSeleccionada;
            }
            set
            {
                _serieSeleccionada = value;
                OnPropertyChanged();
            }
        }



        private string _peso;
        public string Peso
        {
            get
            {
                return _peso;
            }
            set
            {
                _peso = value;
                OnPropertyChanged();
            }
        }



        private string _rir;
        public string Rir
        {
            get
            {
                return _rir;
            }
            set
            {
                _rir = value;
                OnPropertyChanged();
            }
        }




        private DateTime _fecha;
        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
                OnPropertyChanged();
            }
        }



        public ObservableCollection<RegistroViewModel> Registros { get; set; }
        public ICommand AddRegistroCommand { get; set; }

        public AddControlEjercicioViewModel(Models.Ejercicio ejercicio, IEjerciciosService ejerciciosService, IPageService pageService)
        {
            InitializeCommands();
            Fecha = DateTime.Today;
            Ejercicio = ejercicio;
            _ejerciciosService = ejerciciosService;
            _pageService = pageService;
            Registros = new ObservableCollection<RegistroViewModel>();
            for (int i = 1; i <= Ejercicio.NumSeries; i++)
            {
                Registros.Add(new RegistroViewModel() {  Numero = "Serie " + i });
            }
        }

        private void InitializeCommands()
        {
            AddRegistroCommand = new Command(() => AddRegistro());
        }

        private async Task AddRegistro()
        {

            if (string.IsNullOrWhiteSpace(Peso) || string.IsNullOrWhiteSpace(Rir))
            {
                await _pageService.DisplayAlert("Error", "Los campos no pueden estar vacíos", "Ok");
                return;
            }

            var registro  = new Registro()
            {
                Fecha = this.Fecha,
                Peso = float.Parse(Peso),
                Rir = int.Parse(Rir),
                Serie = SerieSeleccionada + 1,
            };
            var registroCreado = await _ejerciciosService.AddRegistroToEjercicio(Ejercicio, registro);
            MessagingCenter.Send(this, Events.REGISTRO_ADDED, registroCreado);
            await _pageService.PopAsync();
        }
    }
}
