using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GymFit.Converters
{
    using System.Globalization;

    public class NotEmptyStringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string cadena)
            {
                return !string.IsNullOrWhiteSpace(cadena);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
