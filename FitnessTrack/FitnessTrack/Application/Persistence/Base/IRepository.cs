using System;
using System.Linq;
using AppContext = FitnessTrack.Infraestructure.Persistence.AppContext;

namespace FitnessTrack.Application.Persistence.Base
{
    using AppContext = AppContext;

    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        IQueryable<TEntity> GetAll();
        void Add(TEntity entityToAdd);
    }
}
