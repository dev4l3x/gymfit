using FitnessTrack.Configuration;
using FitnessTrack.Helpers;
using FitnessTrack.Models;
using FitnessTrack.Persistence.Base;
using FitnessTrack.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessTrack.ViewModels.Routines
{
    public class AddRoutineViewModel : BaseViewModel
    {

        private IMessagingService _messagingService;
        private IUnitOfWork _unitOfWork;

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

        public AddRoutineViewModel(IMessagingService messagingService, IUnitOfWork unit)
        {
            _messagingService = messagingService;
            _unitOfWork = unit;
            _messagingService.Subscribe<object, Exercise>(this, Events.AddExercise, OnAddExercise);
            Exercises = new ObservableCollection<Exercise>();
            CreateRoutineCommand = new LockCommand(CreateRoutine, true);
        }

        public async void OnAddExercise(object sender, Exercise exercise)
        {
            Exercises.Add(exercise);
            //await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task CreateRoutine()
        {
            var routine = new Routine
            {
                Description = Description,
                Name = Name,
                Exercises = Exercises
            };

            _unitOfWork.RoutineRepository.Add(routine);
            await _unitOfWork.SaveAsync();
            _messagingService.Send<object>(this, Events.AddRoutine);
        }
        
    }
}
