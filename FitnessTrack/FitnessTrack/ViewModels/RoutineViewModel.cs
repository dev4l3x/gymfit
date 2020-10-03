using FitnessTrack.Configuration;
using FitnessTrack.Models;
using FitnessTrack.Persistence.Base;
using FitnessTrack.Repositories;
using FitnessTrack.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrack.ViewModels
{
    public class RoutineViewModel : BaseViewModel
    {
        private IUnitOfWork _unitOfWork;
        private IMessagingService _messagingService;

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


        public RoutineViewModel(IUnitOfWork unitOfWork, IMessagingService messaging)
        {
            _unitOfWork = unitOfWork;
            _messagingService = messaging;
            _messagingService.Subscribe<object>(this, Events.AddRoutine, (sender) => {
                var routin = unitOfWork.RoutineRepository.GetAll();
                Routines = new ObservableCollection<Routine>(routin);
            });
            Routines = new ObservableCollection<Routine>();
            var routine = new Routine
            {
                Name = "prueba",
                Description = "prueba",
                IsActive = false
            };

            unitOfWork.RoutineRepository.Add(routine);
            unitOfWork.Save();

            var routines = unitOfWork.RoutineRepository.GetAll();
            Routines = new ObservableCollection<Routine>(routines);
        }

        private async Task Init()
        {
        }
    }
}
