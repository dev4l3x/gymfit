using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessTrack.Helpers
{
    public static class BarBackgroundColorChanger
    {

        public static BindableProperty BarBackgroundColorProperty = BindableProperty.CreateAttached(
            propertyName: "BarBackgroundColor",
            returnType: typeof(Color),
            declaringType: typeof(Page),
            defaultValue: Color.White,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnBarBackgroundColorChanged
        );

        public static Color GetBarBackgroundColor(BindableObject bindable)
        {
            return (Color)bindable.GetValue(BarBackgroundColorProperty);
        }

        private static void OnBarBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (App.Current.MainPage as NavigationPage).BarBackgroundColor = GetBarBackgroundColor(bindable);
        }
    }
}
