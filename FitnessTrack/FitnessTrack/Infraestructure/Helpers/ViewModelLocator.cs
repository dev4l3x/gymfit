using System;
using System.Linq;
using FitnessTrack.Infraestructure.Containers;
using Ninject;
using Xamarin.Forms;

namespace FitnessTrack.Infraestructure.Helpers
{
    public static class ViewModelLocator
    {
        public static BindableProperty AutoFindViewModelProperty = BindableProperty.CreateAttached(
                propertyName: "AutoFindViewModel", 
                returnType: typeof(bool), 
                declaringType: typeof(ViewModelLocator), 
                defaultValue: false, 
                defaultBindingMode: BindingMode.TwoWay, 
                propertyChanged: OnAutoFindViewModelChanged
            );

        private static IKernel _kernel;
        static ViewModelLocator()
        {
            var settings = new NinjectSettings() { LoadExtensions = false };
            _kernel = new StandardKernel(settings, new AppContainer());
        }

        public static bool GetAutoFindViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoFindViewModelProperty);
        }

        public static void SetAutoFindViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoFindViewModelProperty, value);
        }


        private static void OnAutoFindViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var page = bindable as Element;
            if (page == null)
                return;

            var pageType = page.GetType();
            var viewModelType = GetViewModelTypeForPageType(pageType);
            page.BindingContext = GetInstanceForViewModel(viewModelType);

        }

        private static object GetInstanceForViewModel(Type viewModelType)
        {
            return _kernel.Get(viewModelType);
        }

        private static Type GetViewModelTypeForPageType(Type pageType)
        {
            var assembly = pageType.Assembly;
            var viewModelName = GetViewModelNameForPageType(pageType);
            return assembly.GetTypes().ToList().Find((type) => type.Name == viewModelName);
        }

        private static string GetViewModelNameForPageType(Type pageType)
        {
            var fullNamePage = pageType.Name;
            return fullNamePage.Replace("Views", "ViewModels").Replace("Page", "ViewModel");
        }
    }
}
