using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTrack.Repositories
{
    using FitnessTrack.Models;
    using FitnessTrack.Persistence;

    public interface IExerciseRepository : IRepository<Exercise>
    {

    }

    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppContext context) : base(context)
        {

        }
    }
}
