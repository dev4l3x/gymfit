using FitnessTrack.Application.Persistence.Base;

namespace FitnessTrack.Application.UseCases.ExerciseSpecification
{
    public class ExerciseSpecificationCreator
    {

        private IUnitOfWork _unitOfWork;

        public ExerciseSpecificationCreator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateSpecification(Domain.ExerciseSpecification specification)
        {
            var repository = _unitOfWork.GetGenericRepository<Domain.ExerciseSpecification>();
            repository.Add(specification);
            _unitOfWork.Save();
        }
    }
}
