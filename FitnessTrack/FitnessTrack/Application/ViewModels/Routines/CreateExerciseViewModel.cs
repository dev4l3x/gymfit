using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnessTrack.Application.Persistence.Base;
using FitnessTrack.Application.UseCases.Exercise;
using FitnessTrack.Application.UseCases.ExerciseSpecification;
using FitnessTrack.Configuration;
using FitnessTrack.Domain;
using FitnessTrack.Infraestructure.Helpers;
using FitnessTrack.Infraestructure.Persistence.Base;
using FitnessTrack.Infraestructure.Services;
using Xamarin.Forms;

namespace FitnessTrack.Application.ViewModels.Routines
{
    public class CreateExerciseViewModel: BaseViewModel
    {

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
                NotifyPropertyChanged();
            }
        }

        private int _day;
        public int Day
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<object> _sets;
        public ObservableCollection<object> Sets
        {
            get
            {
                return _sets;
            }
            set
            {
                _sets = value;
                NotifyPropertyChanged();
            }
        }


        public ICommand CreateExerciseCommand { get; set; }
        public ICommand AddNewSetCommand { get; set; }

        private ExerciseSpecificationCreator _exerciseSpecificationCreator;
        private ExerciseCreator _exerciseCreator;

        public CreateExerciseViewModel(INavigationService navigationService, ExerciseSpecificationCreator specificationCreator, ExerciseCreator exerciseCreator)
        {
            Sets = new ObservableCollection<object>();
            _exerciseCreator = exerciseCreator;
            _exerciseSpecificationCreator = specificationCreator;
            InitializeComands();
        }

        private void InitializeComands()
        {
            CreateExerciseCommand = new LockCommand(CreateExercise);
            AddNewSetCommand = new Command(() => _ = AddNewSet());
        }

        private async Task AddNewSet()
        {
            Sets.Add(new Set { Reps = 0 });
        }

        private async Task CreateExercise()
        {
            var specification = new ExerciseSpecification
            {
                Description = Description,
                Name = Name
            };


            var exercise = new Exercise
            {
                Day = Day,
                Specification = specification
            };

            _exerciseCreator.CreateExercise(exercise);

        }
    }
}
