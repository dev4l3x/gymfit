using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Converters
{
    using System.Globalization;
    using Models;
    using Xamarin.Forms;

    public class RutinaObtenidaToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Rutina rutina)
            {
                return rutina.Compartida && (rutina.Publicador == null ||
                                             rutina.Publicador.Username != rutina.Propietario.Username);
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
