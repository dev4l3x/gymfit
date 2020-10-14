using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTrack.Application.Persistence.Base;
using FitnessTrack.Application.UseCases.ExerciseSpecification;

namespace FitnessTrack.Application.UseCases.Exercise
{
    using Domain;
    public class ExerciseCreator
    {
        private IUnitOfWork _unitOfWork;
        private ExerciseSpecificationCreator _specificationCreator;

        public ExerciseCreator(IUnitOfWork unitOfWork, ExerciseSpecificationCreator specificationCreator)
        {
            _unitOfWork = unitOfWork;
            _specificationCreator = specificationCreator;
        }

        public void CreateExercise(Exercise exercise)
        {
            if(exercise.Specification.Id == Guid.Empty)
                _specificationCreator.CreateSpecification(exercise.Specification);
            _unitOfWork.ExerciseRepository.Add(exercise);
            _unitOfWork.Save();
        }
    }
}
