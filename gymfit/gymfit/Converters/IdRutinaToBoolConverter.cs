using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GymFit.Converters
{
    using System.Numerics;

    public class IdRutinaToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var rutinaId = (BigInteger)value;
            int rutinaActiva = -1; 
            var activeRutinaTask = Task.Run(async () => { rutinaActiva = int.Parse(await SecureStorage.GetAsync("RutinaActiva") ?? "-1"); });
            activeRutinaTask.Wait();

            if (rutinaId == rutinaActiva)
                return true;
            return false;
        }

        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
