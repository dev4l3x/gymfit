using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTrack.ViewModels.Routines
{
    using FitnessTrack.Configuration;
    using FitnessTrack.Helpers;
    using FitnessTrack.Models;
    using FitnessTrack.Persistence.Base;
    using FitnessTrack.Services;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CreateExerciseViewModel: BaseViewModel
    {

        private IUnitOfWork _unitOfWork;
        private INavigationService _navigationService;
        private IMessagingService _messagingService;

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

        private ObservableCollection<Set> _sets;
        public ObservableCollection<Set> Sets
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

        public CreateExerciseViewModel(IUnitOfWork unitOfWork, INavigationService navigationService, IMessagingService messagingService)
        {
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _messagingService = messagingService;
            Sets = new ObservableCollection<Set>();

            InitializeComands();
        }

        private void InitializeComands()
        {
            CreateExerciseCommand = new LockCommand(CreateExercise);
            AddNewSetCommand = new Command(() => _ = AddNewSet());
        }

        private async Task AddNewSet()
        {
            var response = await _navigationService.DisplayPromptAndGetResponseAysnc("Nueva serie", "¿De cuantas repeticiones es esta series?", "Añadir", "Cancelar", default, 3, Keyboard.Numeric);
            if(int.TryParse(response, out var value))
            {
                Sets.Add(new Set { Reps = value });
            }
            else
            {
                await _navigationService.DisplayAlertAsync("Error", "El número de repiticiones tiene que ser un valor númerico", "Ok");
            }
        }

        private async Task CreateExercise()
        {
            var specification = new ExerciseSpecification
            {
                Description = Description,
                Name = Name
            };

            var specificationRepository = _unitOfWork.GetGenericRepository<ExerciseSpecification>();
            specificationRepository.Add(specification);
            await _unitOfWork.SaveAsync();

            var exercise = new Exercise
            {
                Day = Day,
                Specification = specification,
                Sets = Sets.ToList()
            };

            _messagingService.Send<object, Exercise>(this, Events.AddExercise, exercise);
            await _navigationService.PopAsync(2);
        }
    }
}
