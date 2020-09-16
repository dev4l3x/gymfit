using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Helpers
{
    using System.Linq;
    using Models;
    using Syncfusion.SfChart.XForms;
    using Xamarin.Forms.Internals;

    public static class RegistrosChartHelper
    {

        public static IEnumerable<ChartDataPoint> GetRegistrosByDay(IEnumerable<RegistroPeso> registrosDesordenados)
        {
            var toret = new List<ChartDataPoint>();
            var actualMonth = DateTime.Today.Month;
            var currentYear = DateTime.Today.Year;

            var registros =
                registrosDesordenados.Where((registro) => registro.FechaRegistro.Month == actualMonth);

            double lastMarca = 0;
            for (int day = 1; day <= DateTime.DaysInMonth(currentYear, actualMonth); day++)
            {
                var registro = registros.ToList().Find((rgs) => rgs.FechaRegistro.Day == day);
                if (registro == null)
                {
                    toret.Add(new ChartDataPoint(new DateTime(currentYear, actualMonth, day), lastMarca));
                }
                else
                {
                    lastMarca = registro.Peso;
                    toret.Add(new ChartDataPoint(registro.FechaRegistro, lastMarca));
                }
            }


            return toret;
        }

        public static IEnumerable<ChartDataPoint> GetRegistrosByMonth(IEnumerable<RegistroPeso> registros)
        {
            List<ChartDataPoint> registrosPorMeses = new List<ChartDataPoint>();
            var actualYear = DateTime.Today.Year;
            var numberOfMonths = 12;
            var currentYearRegistros = registros.Where((registro) => registro.FechaRegistro.Year == actualYear);
            double lastMedia = 0;
            for (int i = 1; i <= numberOfMonths; i++)
            {
                var registrosEnMes = currentYearRegistros.Where((registro) => registro.FechaRegistro.Month == i);
                if (registrosEnMes.Count() > 0)
                {
                    lastMedia = GetMediaForPesos(registrosEnMes);
                    registrosPorMeses.Add(new ChartDataPoint(i, lastMedia));
                }
                else
                {
                    registrosPorMeses.Add(new ChartDataPoint(i, lastMedia));

                }
            }

            return registrosPorMeses;
        }

        public static IEnumerable<ChartDataPoint> GetRegistrosByYear(IEnumerable<RegistroPeso> registros)
        {
            List<ChartDataPoint> registrosPorYears = new List<ChartDataPoint>();
            var years = GetSquenceOfYears(registros);
            foreach (var year in years)
            {
                var registrosParaYear = registros.Where((registro) => registro.FechaRegistro.Year == year);
                registrosPorYears.Add(new ChartDataPoint(year, GetMediaForPesos(registrosParaYear)));
            }

            return registrosPorYears;
        }

        private static IEnumerable<int> GetSquenceOfYears(IEnumerable<RegistroPeso> registros)
        {
            var yearsList = new List<int>();
            registros.ForEach((registro) => yearsList.Add(registro.FechaRegistro.Year));
            yearsList.Sort();
            return yearsList.Distinct();
        }
        private static double GetMediaForPesos(IEnumerable<RegistroPeso> registros)
        {
            double media = 0;
            foreach (var registroPeso in registros)
            {
                media += registroPeso.Peso;
            }

            return media / registros.Count();
        }
    }
}
