using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FitnessTrack.Configuration;
using FitnessTrack.Domain;
using FitnessTrack.Infraestructure.Persistence.Base;
using FitnessTrack.Infraestructure.Services;

namespace FitnessTrack.Application.ViewModels
{
    public class RoutineViewModel : BaseViewModel
    {
        private ObservableCollection<Routine> _routines;
        public ObservableCollection<Routine> Routines
        {
            get
            {
                return _routines;
            }
            set
            {
                _routines = value;
                NotifyPropertyChanged();
            }
        }


        public RoutineViewModel()
        {
            Routines = new ObservableCollection<Routine>();
            var routine = new Routine
            {
                Name = "prueba",
                Description = "prueba",
                IsActive = false
            };

            //unitOfWork.RoutineRepository.Add(routine);
            //unitOfWork.Save();

            //var routines = unitOfWork.RoutineRepository.GetAll();
            //Routines = new ObservableCollection<Routine>(routines);
        }

        private async Task Init()
        {
        }
    }
}
