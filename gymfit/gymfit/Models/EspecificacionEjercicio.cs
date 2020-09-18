using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymFit.Models
{
    public class EspecificacionEjercicio : Entity
    {
        private string _imagenes;
        private string _descripcion;
        private string _nombre;
        private List<MUSCULOS> _musculosPrincipales;
        private List<MUSCULOS> _musculosSecundarios;
        private Usuario _creador;

        [JsonProperty("musculos_secundarios")]
        public List<MUSCULOS> MusculosSecundarios { get => _musculosSecundarios; set => _musculosSecundarios = value; }
        [JsonProperty("musculos_principales")]
        public List<MUSCULOS> MusculosPrincipales { get => _musculosPrincipales; set => _musculosPrincipales = value; }
        [JsonProperty("nombre")]
        public string Nombre { get => _nombre; set => _nombre = value; }
        [JsonProperty("descripcion")]
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Imagenes { get => _imagenes; set => _imagenes = value; }
        internal Usuario Creador { get => _creador; set => _creador = value; }

        public List<string> ImagenesList
        {
            get
            {
                
                if (string.IsNullOrWhiteSpace(Imagenes))
                {
                    var toret = new List<string>();
                    toret.Add("no-image.png");
                    return toret;
                }
                var splitted = _imagenes.Split(';');
                return splitted.ToList();
            }
        }

        public string MusculosPrincipalesAsString
        {
            get
            {
                string toret = "";
                if (MusculosPrincipales == null)
                    return toret;
                foreach (var musculo in MusculosPrincipales)
                {
                    toret += musculo.ToString().ToLower() + ", ";
                }
                if (!string.IsNullOrWhiteSpace(toret))
                {
                    toret = toret.Remove(toret.Length - 2, 2);
                }
                return toret;
            }
        }

        public string MusculosSecundariosAsString
        {
            get
            {
                string toret = "";
                if (MusculosSecundarios == null)
                    return toret;
                foreach (var musculo in MusculosSecundarios)
                {
                    toret += musculo.ToString().ToLower() + ", ";
                }
                if(!string.IsNullOrWhiteSpace(toret))
                {
                    toret = toret.Remove(toret.Length - 2, 2);
                }
                return toret;
            }
        }

    }
}
