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
            var rutina = value as Rutina;
            if (rutina != null)
            {
                return rutina.Compartida && rutina.Publicador != null && rutina.Propietario.Username == rutina.Publicador.Username;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
