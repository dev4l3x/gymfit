using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTrack.ViewModels.Routines
{
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

        private ObservableCollection<int> _sets;
        public ObservableCollection<int> Sets
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

        public CreateExerciseViewModel(IUnitOfWork unitOfWork, INavigationService navigationService)
        {
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;

            Sets = new ObservableCollection<int>();

            InitializeComands();
        }

        private void InitializeComands()
        {
            CreateExerciseCommand = new Command(() => CreateExercise());
            AddNewSetCommand = new Command(() => _ = AddNewSet());
        }

        private async Task AddNewSet()
        {
            var response = await _navigationService.DisplayPromptAndGetResponseAysnc("Nueva serie", "¿De cuantas repeticiones es esta series?", "Añadir", "Cancelar", default, 3, Keyboard.Numeric);
            if(int.TryParse(response, out var value))
            {
                Sets.Add(value);
            }
            else
            {
                await _navigationService.DisplayAlertAsync("Error", "El número de repiticiones tiene que ser un valor númerico", "Ok");
            }
        }

        private void CreateExercise()
        {
            var specification = new ExerciseSpecification
            {
                Description = Description,
                Name = Name
            };

            var specificationRepository = _unitOfWork.GetGenericRepository<ExerciseSpecification>();
            specificationRepository.Add(specification);

            var exercise = new Exercise
            {
                Day = Day,
                Specification = specification,
                Sets = Sets.ToList()
            };
        }
    }
}
