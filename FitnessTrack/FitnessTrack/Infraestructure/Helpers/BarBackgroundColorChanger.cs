using FitnessTrack.Domain;
using Xamarin.Forms;

namespace FitnessTrack.Infraestructure.Helpers
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
