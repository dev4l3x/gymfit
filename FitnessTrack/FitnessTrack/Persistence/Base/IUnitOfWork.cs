using FitnessTrack.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTrack.Persistence.Base
{
    public interface IUnitOfWork
    {
        IRoutineRepository RoutineRepository { get; }
        IExerciseRepository ExerciseRepository { get; }
        IRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class;
        int Save();
    }

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

        public IRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(AppContext);
        }
    }
}
