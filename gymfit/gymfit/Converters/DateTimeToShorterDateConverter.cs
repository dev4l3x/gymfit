using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Converters
{
    using System.Globalization;
    using Xamarin.Forms;

    public class DateTimeToShorterDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime) value;
            if(date != null )
            {
                return date.ToShortDateString();
            }

            return default(DateTime);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return default(DateTime);
        }
    }
}
