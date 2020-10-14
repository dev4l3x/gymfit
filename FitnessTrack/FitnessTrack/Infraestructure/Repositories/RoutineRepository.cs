using FitnessTrack.Application.Persistence.Base;
using FitnessTrack.Application.Persistence.Repositories;
using FitnessTrack.Domain;

namespace FitnessTrack.Infraestructure.Repositories
{

    public class RoutineRepository : Repository<Routine>, IRoutineRepository
    {
        public RoutineRepository(Persistence.AppContext context) : base(context)
        {
        }
    }
}
