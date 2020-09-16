using GymFit.Models;
using GymFit.Services.Intefaces;
using GymFit.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymFit.ViewModels.Ejercicio
{
    public class CrearEjercicioPesonalizadoViewModel : BaseViewModel
    {
        private IPageService _pageService;
        private IEspecificacionEjerciciosService _ejerciciosService;



        private string _nombre;
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



        private string _descripcion;

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

        public List<MUSCULOS> MusculosPrincipales { get; set; }
        public List<MUSCULOS> MusculosSecundarios { get; set; }





        public ICommand CrearEjercicioCommand { get; set; }
        public ICommand MusculosPrincipalesChangedCommand { get; set; }
        public ICommand MusculosSecundariosChangedCommand { get; set; }

        public CrearEjercicioPesonalizadoViewModel(IEspecificacionEjerciciosService ejerciciosService, IPageService pageService)
        {
            InitializeCommands();
            _ejerciciosService = ejerciciosService;
            _pageService = pageService;
            MusculosPrincipales = new List<MUSCULOS>();
            MusculosSecundarios = new List<MUSCULOS>();
        }

        public void InitializeCommands()
        {
            CrearEjercicioCommand = new Command(async () =>
            {
                if(await ValidateAll())
                {
                    var especificacion = new EspecificacionEjercicio() {
                        Nombre = Nombre,
                        Descripcion = Descripcion,
                        MusculosPrincipales = MusculosPrincipales, 
                        MusculosSecundarios = MusculosSecundarios
                    };
                    _ejerciciosService.CrearEspecificacionEjercicio(especificacion);
                    await _pageService.PopAsync();
                }
            });

            MusculosPrincipalesChangedCommand = new Command((lista) => {

                var selectedItems = lista as IList;
                MusculosPrincipales.Clear();
                foreach(var element in selectedItems)
                {
                    MusculosPrincipales.Add((MUSCULOS)Enum.Parse(typeof(MUSCULOS), element as string));
                }

            });

            MusculosSecundariosChangedCommand = new Command((lista) => {
                var selectedItems = lista as IList;
                MusculosSecundarios.Clear();
                foreach (var element in selectedItems)
                {
                    MusculosSecundarios.Add((MUSCULOS)Enum.Parse(typeof(MUSCULOS), element as string));
                }
            });
        }

        public async Task<bool> ValidateAll()
        {
            if(string.IsNullOrWhiteSpace(Nombre))
            {
                await _pageService.DisplayAlert("Error", "El nombre no puede estar vacío", "Ok");
                return false;
            }
            else if(MusculosPrincipales.Count == 0)
            {
                await _pageService.DisplayAlert("Error", "Debes seleccionar al menos un músculo principal", "Ok");
                return false;
            }
            return true;
        }
    }
}
