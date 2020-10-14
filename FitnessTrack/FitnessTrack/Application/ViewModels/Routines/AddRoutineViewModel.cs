using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnessTrack.Application.UseCases.Routine;
using FitnessTrack.Configuration;
using FitnessTrack.Domain;
using FitnessTrack.Infraestructure.Helpers;
using FitnessTrack.Infraestructure.Persistence.Base;
using FitnessTrack.Infraestructure.Services;

namespace FitnessTrack.Application.ViewModels.Routines
{
    public class AddRoutineViewModel : BaseViewModel
    {

        private RoutineCreator _routineCreator;

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        private string _days;
        public string Days
        {
            get
            {
                return _days;
            }
            set
            {
                _days = value;
            }
        }

        public ObservableCollection<Exercise> Exercises { get; set; }

        public ICommand CreateRoutineCommand { get; set; }

        public AddRoutineViewModel(RoutineCreator routineCreator)
        {
            _routineCreator = routineCreator;
            Exercises = new ObservableCollection<Exercise>();
            CreateRoutineCommand = new LockCommand(CreateRoutine, true);
        }


        public async Task CreateRoutine()
        {
            var routine = new Routine
            {
                Description = Description,
                Name = Name,
                Exercises = Exercises
            };

            //_unitOfWork.RoutineRepository.Add(routine);
            //await _unitOfWork.SaveAsync();
            //_messagingService.Send<object>(this, Events.AddRoutine);
            //await _navigationService.PopAsync();
            _routineCreator.Create(routine);
        }
        
    }
}
