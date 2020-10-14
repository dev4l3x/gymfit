using FitnessTrack.Application.Persistence.Base;
using FitnessTrack.Application.Persistence.Repositories;
using FitnessTrack.Domain;
using FitnessTrack.Infraestructure.Persistence;

namespace FitnessTrack.Infraestructure.Repositories
{
    

    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppContext context) : base(context)
        {

        }
    }
}
