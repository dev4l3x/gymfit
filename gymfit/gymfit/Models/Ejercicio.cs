using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Models
{
    public class Ejercicio : Entity, ICloneable
    {
        private EspecificacionEjercicio _especificacion;
        private List<int> _numerosRepeticiones = new List<int>();
        private int _indexDay;

        public Ejercicio()
        {

        }

        public Ejercicio(EspecificacionEjercicio especificacion, IEnumerable<int> numerosRepeticiones)
        {
            Especificacion = especificacion;
            NumerosRepeticiones.AddRange(numerosRepeticiones);
        }

        [JsonProperty("especificacion")]
        public EspecificacionEjercicio Especificacion { get => _especificacion; set => _especificacion = value; }
        public int NumSeries
        {
            get
            {
                return this._numerosRepeticiones.Count;
            }
        }
        public List<int> NumerosRepeticiones { get => _numerosRepeticiones; set => _numerosRepeticiones = value; }

        [JsonProperty("repeticiones")]
        public string SeriesRepeticiones
        {
            get
            {
                if(NumerosRepeticiones != null && NumerosRepeticiones.Count > 0)
                {
                    var repeticiones =  String.Join(" - ", NumerosRepeticiones.ToArray());
                    return string.Format("{0} series de {1} repeticiones", NumerosRepeticiones.Count, repeticiones);
                }
                return string.Empty;
            }
            set
            {
                var repeticionesSeparadas = value;
                var repeticiones = repeticionesSeparadas.Trim().Split('-');
                foreach (var repeticion in repeticiones)
                {
                    if (int.TryParse(repeticion, out var parsedRepeticion))
                        NumerosRepeticiones.Add(parsedRepeticion);
                }
            }
        }
        [JsonProperty("dia")]
        public int IndexDay { get => _indexDay; set => _indexDay = value; }

        [JsonIgnore]
        public float TiempoEstimadoEnMinutos
        {
            get
            {
                int tiempo = 0;
                tiempo += NumerosRepeticiones.Count * 45;
                tiempo += (NumerosRepeticiones.Count - 1) * 90;
                return tiempo / 60;
            }
        }

        public List<Registro> Registros { get; set; }

        public object Clone()
        {
            return new Ejercicio()
            {
                Especificacion = Especificacion,
                NumerosRepeticiones = NumerosRepeticiones,
                IndexDay = IndexDay
            };
        }
    }
}
