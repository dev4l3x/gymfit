using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTrack.Application.Persistence.Base;
using AppContext = FitnessTrack.Infraestructure.Persistence.AppContext;

namespace FitnessTrack.Infraestructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected Persistence.AppContext AppContext { get; set; }

        public Repository(AppContext context)
        {
            AppContext = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return AppContext.Set<TEntity>();
        }

        public void Add(TEntity entityToAdd)
        {
            AppContext.Add(entityToAdd);
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
