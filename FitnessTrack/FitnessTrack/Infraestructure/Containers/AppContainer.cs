using FitnessTrack.Application.Persistence.Base;
using FitnessTrack.Infraestructure.Persistence.Base;
using FitnessTrack.Infraestructure.Repositories;
using FitnessTrack.Infraestructure.Services;
using Ninject.Modules;
using AppContext = FitnessTrack.Infraestructure.Persistence.AppContext;

namespace FitnessTrack.Infraestructure.Containers
{
    public class AppContainer : NinjectModule
    {
        public override void Load()
        {
            
            Bind<IUnitOfWork>().ToMethod((context) =>
            {
                AppContext appContext = new AppContext();
                return new UnitOfWork(
                    appContext, 
                    new RoutineRepository(appContext),
                    new ExerciseRepository(appContext)
                );
            }).InSingletonScope();

            Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            Bind<IMessagingService>().To<MessagingService>().InSingletonScope();

        }
    }
}
