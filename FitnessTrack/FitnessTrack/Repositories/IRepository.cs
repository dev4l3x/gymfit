using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FitnessTrack.Repositories
{
    using AppContext = FitnessTrack.Persistence.AppContext;

    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        IQueryable<TEntity> GetAll();
        void Add(TEntity entityToAdd);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected AppContext AppContext { get; set; }

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
