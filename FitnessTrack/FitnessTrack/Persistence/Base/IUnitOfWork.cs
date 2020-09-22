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
        int Save();
    }

    public class UnitOfWork : IUnitOfWork
    {

        public AppContext AppContext { get; set; }

        public IRoutineRepository RoutineRepository { get; }

        public UnitOfWork(AppContext appContext, IRoutineRepository routineRepository)
        {
            AppContext = appContext;
            RoutineRepository = routineRepository;
        }

        public int Save()
        {
            return AppContext.SaveChanges();
        }
    }
}
