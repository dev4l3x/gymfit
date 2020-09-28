using FitnessTrack.Persistence.Base;
using FitnessTrack.Repositories;
using FitnessTrack.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTrack.Containers
{
    public class AppContainer : NinjectModule
    {
        public override void Load()
        {
            
            Bind<IUnitOfWork>().ToMethod((context) =>
            {
                Persistence.AppContext appContext = new Persistence.AppContext();
                return new UnitOfWork(
                    appContext, 
                    new RoutineRepository(appContext),
                    new ExerciseRepository(appContext)
                );
            }).InSingletonScope();

            Bind<INavigationService>().To<NavigationService>().InSingletonScope();

        }
    }
}
