using GymFit.Services;
using GymFit.Services.Intefaces;
using GymFit.Services.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit
{

    /// <summary>
    /// Se encarga de configurar Ninject para la inyeccion de dependencias.
    /// </summary>
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPageService>().To<PageService>().InSingletonScope();
            Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            Bind<IUserInfo>().To<UserInfo>().InSingletonScope();
            Bind<ISerializer>().To<JsonSerializer>().InSingletonScope();
            Bind<ISettingsStore>().To<SettingsStore>();
            Bind<IRutinasService>().To<MockRutinasService>();
        }
    }
}
