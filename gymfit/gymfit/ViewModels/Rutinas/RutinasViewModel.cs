using GymFit.Models;
using GymFit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using GymFit.Views.Rutinas;
using System.Threading;
using Xamarin.Essentials;

namespace GymFit.ViewModels.Rutinas
{
    public class RutinasViewModel : BaseViewModel
    {

        private IRutinasService _rutinasService;
        private IPageService _pageService;

        public ObservableCollection<Rutina> Rutinas { get; set; }

        #region Commands

        public ICommand CreateRutinaCommand { get; set; }
        public ICommand RutinaSelectedCommand { get; set; }
        public ICommand DeleteRutinaCommand { get; set; }
        public ICommand ActiveRutinaCommand { get; set; }

        #endregion

        public RutinasViewModel(IRutinasService rutinasService, IPageService pageService)
        {
            InitializeCommands();
            _rutinasService = rutinasService;
            _pageService = pageService;
            Rutinas = new ObservableCollection<Rutina>();
            FetchRutinas();
            MessagingCenter.Subscribe<AddRutinaViewModel, Rutina>(this, Events.ADD_RUTINA, OnAddRutina);
        }

        private void OnAddRutina(AddRutinaViewModel sender, Rutina arg)
        {
            FetchRutinas();
        }

        public void InitializeCommands()
        {
            CreateRutinaCommand = new Command(() => ElegirCreacionRutina());
            RutinaSelectedCommand = new Command((rutina) => RutinaSelected(rutina as Rutina));
            DeleteRutinaCommand = new Command((rutina) => DeleteRutina(rutina as Rutina));
            ActiveRutinaCommand = new Command((rutina) => ActiveRutina(rutina as Rutina));
        }


        private async void ElegirCreacionRutina()
        {
            var response = await _pageService.DisplayActionSheet("Elige una opción", "Cancelar", "Crear rutina de cero", "Generar rutina");
            if(response == "Crear rutina de cero")
            {
                ShowAddRutinaPage();
            }
            else if(response == "Generar rutina")
            {
            }
        }


        private async void ActiveRutina(Rutina rutina)
        {
            _rutinasService.MarcarComoActiva(rutina);

            var aux = new List<Rutina>(Rutinas);
            Rutinas.Clear();
            foreach(Rutina r in aux)
            {
                Rutinas.Add(r);
            }
            
        }

        private async void DeleteRutina(Rutina rutina)
        {
            if(rutina != null)
            {
                Rutinas.Remove(rutina);
                if(!await _rutinasService.DeleteRutina(rutina))
                {
                    await _pageService.DisplayAlert("Error al eliminar", "Se ha producido un error al intentar eliminar la rutina", "Ok");
                    Rutinas.Add(rutina);
                }
            }
        }

        private void RutinaSelected(Rutina rutina)
        {
            if(rutina != null)
            {
                _pageService.PushAsync(new DetalleRutinaPage(rutina));
            }
        }

        public async void ShowAddRutinaPage()
        {
            await _pageService.PushAsync(new AddRutinaPage());
        }

        public async void FetchRutinas()
        {
            var rutinas = await _rutinasService.GetRutinasOfLoggedUser();
            Rutinas.Clear();
            foreach(var rutina in rutinas)
            {
                Rutinas.Add(rutina);
            }
        }
    }
}
