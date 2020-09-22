using FitnessTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrack.Repositories
{

    public interface IRoutineRepository : IRepository<Routine>
    {
    }


    public class RoutineRepository : Repository<Routine>, IRoutineRepository
    {
        public RoutineRepository(Persistence.AppContext context) : base(context)
        {
        }
    }
}
