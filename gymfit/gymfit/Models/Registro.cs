using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Models
{
    using Configuration;
    using Newtonsoft.Json;

    public class Registro : Entity
    {
        public DateTime Fecha { get; set; }

        [JsonProperty("fecha")]
        public string FechaTexto
        {
            get => Fecha.ToString(GlobalConfiguration.DateFormat);
            set => Fecha = DateTime.ParseExact(value, GlobalConfiguration.DateFormat, System.Globalization.CultureInfo.InvariantCulture);
        }
        [JsonProperty("peso")]
        public float Peso { get; set; }
        [JsonProperty("rir")]
        public int Rir { get; set; }
        [JsonProperty("serie")]
        public int Serie { get; set; }
    }
}
