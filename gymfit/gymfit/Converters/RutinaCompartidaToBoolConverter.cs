using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Converters
{
    using System.Globalization;
    using Models;
    using Xamarin.Forms;

    public class RutinaCompartidaToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
