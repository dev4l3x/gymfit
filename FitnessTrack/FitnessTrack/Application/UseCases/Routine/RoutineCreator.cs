using FitnessTrack.Application.Persistence.Base;

namespace FitnessTrack.Application.UseCases.Routine
{
    public class RoutineCreator
    {

        private IUnitOfWork _unitOfWork;

        public RoutineCreator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Domain.Routine routine)
        {
            _unitOfWork.RoutineRepository.Add(routine);
            _unitOfWork.Save();
        }
    }
}
