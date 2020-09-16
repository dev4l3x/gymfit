using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Converters
{
    using System.Globalization;
    using Xamarin.Forms;

    public class StringToShorterStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var maxLenght = 40;
            if (value is String cadena && cadena.Length > maxLenght)
            {
                return cadena.Substring(0, maxLenght - 3) + "...";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
