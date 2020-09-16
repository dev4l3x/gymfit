using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Services
{
    using Xamarin.Forms;

    public interface INavigationService
    {
        void SetCurrentPage<TPage>();
        void SetCurrentPageWrappedInNavigation<TPage>();
    }

    public class NavigationService : INavigationService
    {
        public void SetCurrentPage<TPage>()
        {
            App.Current.MainPage = GetInstanceForPageWithType(typeof(TPage));
        }

        public void SetCurrentPageWrappedInNavigation<TPage>()
        {
            var page = GetInstanceForPageWithType(typeof(TPage));
            App.Current.MainPage = new NavigationPage(page)
            {
                BarBackgroundColor = Color.Transparent,
                BarTextColor = Color.Black
            };
        }

        private Page GetInstanceForPageWithType(Type pageType)
        {
            return Activator.CreateInstance(pageType) as Page;
        }
    }
}
