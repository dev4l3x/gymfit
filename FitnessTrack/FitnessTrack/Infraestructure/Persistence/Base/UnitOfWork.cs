using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTrack.Application.Persistence.Base;
using FitnessTrack.Application.Persistence.Repositories;
using FitnessTrack.Infraestructure.Repositories;

namespace FitnessTrack.Infraestructure.Persistence.Base
{
    public class UnitOfWork : IUnitOfWork
    {

        public AppContext AppContext { get; set; }

        public IRoutineRepository RoutineRepository { get; }
        public IExerciseRepository ExerciseRepository { get; }

        public UnitOfWork(AppContext appContext, IRoutineRepository routineRepository, IExerciseRepository exerciseRepository)
        {
            AppContext = appContext;
            RoutineRepository = routineRepository;
            ExerciseRepository = exerciseRepository;
        }

        public int Save()
        {
            return AppContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await AppContext.SaveChangesAsync();
        }

        public IRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(AppContext);
        }
    }
}
