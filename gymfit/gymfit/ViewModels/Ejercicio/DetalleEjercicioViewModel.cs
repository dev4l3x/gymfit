using GymFit.Models;
using GymFit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymFit.ViewModels.Ejercicio
{
    public class DetalleEjercicioViewModel : BaseViewModel
    {

        private EspecificacionEjercicio _especificacion;
        private IPageService _pageService;
        public ObservableCollection<int> NumerosRepeticiones { get; set; }



        
        public EspecificacionEjercicio Especificacion
        {
            get
            {
                return _especificacion;
            }
            set
            {
                _especificacion = value;
                OnPropertyChanged();
            }
        }


        public ICommand AddSerieEjercicioCommand { get; set; }
        public ICommand AddEjercicioCommand { get; set; } 
        public ICommand DeleteSerieCommand { get; set; }



        public DetalleEjercicioViewModel(EspecificacionEjercicio especificacion, IPageService pageService)
        {
            InitializeCommands();
            Especificacion = especificacion;
            _pageService = pageService;
            NumerosRepeticiones = new ObservableCollection<int>();
        }

        public void InitializeCommands()
        {
            AddEjercicioCommand = new Command(() => NotifyAddEjercicio());
            AddSerieEjercicioCommand = new Command(() => AddSerieEjercicio());
            DeleteSerieCommand = new Command<int>((index) => DeleteSerie(index));
        }

        private void DeleteSerie(int index)
        {
            if (index >= 0 && index < NumerosRepeticiones.Count)
                NumerosRepeticiones.RemoveAt(index);
        }

        private async void AddSerieEjercicio()
        {
            string result = await _pageService.DisplayPromptAsync("¿Cuantas repeticiones?", "Introduce el número de repeticiones para esta serie", "1", keyboardType: Keyboard.Numeric);
            if(!string.IsNullOrWhiteSpace(result) && int.TryParse(result, out var repeticiones))
            {
                NumerosRepeticiones.Add(repeticiones);
            }
        }

        public async void NotifyAddEjercicio()
        {
            
            MessagingCenter.Send<DetalleEjercicioViewModel, Models.Ejercicio>(this, Events.ADD_EJERCICIO, new Models.Ejercicio(Especificacion, NumerosRepeticiones));
           
             await _pageService.PopPagesAsync(2);
            
        }

    }
}
