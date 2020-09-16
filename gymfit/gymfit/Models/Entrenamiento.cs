using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Models
{
    public class Entrenamiento : Entity
    {
        private int _tiempo;
        private EspecificacionEntrenamiento _especificacion;
        private int _kcalQuemadas;

        [JsonProperty("kcal_quemadas")]
        public int KcalQuemadas { get => _kcalQuemadas; set => _kcalQuemadas = value; }
        [JsonProperty("tiempo")]
        public int Tiempo { get => _tiempo; set => _tiempo = value; }

        [JsonProperty("especificacion")]
        public EspecificacionEntrenamiento Especificacion { get => _especificacion; set => _especificacion = value; }

        public string KcalQuemadasMinutos
        {
            get
            {
                return this.KcalQuemadas + " kcal - " + this.Tiempo + " minutos"; 
            }
        }
    }
}
