using System.Threading.Tasks;
using FitnessTrack.Application.Persistence.Repositories;

namespace FitnessTrack.Application.Persistence.Base
{
    public interface IUnitOfWork
    {
        IRoutineRepository RoutineRepository { get; }
        IExerciseRepository ExerciseRepository { get; }
        IRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class;
        int Save();
        Task<int> SaveAsync();
    }

}
