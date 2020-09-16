using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Models
{

    public enum NIVEL { PRINCIPIANTE, INTERMEDIO, AVANZADO }
    public class Rutina : Entity
    {
        private string _nombre;
        private NIVEL _nivel;
        private int _numDiasSemana;
        private string _descripcion;
        private bool _archivada;
        private bool _compartida;
        private List<List<Ejercicio>> _ejerciciosDays;
        private Usuario _propietario;

        public Rutina(NIVEL nivel, int numDiasSemana, string descripcion, string nombre, IEnumerable<Ejercicio> ejercicios)
        {
            Nivel = nivel;
            NumDiasSemana = numDiasSemana;
            Descripcion = descripcion;
            Nombre = nombre;
            Ejercicios = new List<Ejercicio>(ejercicios);
            
        }
        

        public Rutina(NIVEL nivel, int numDiasSemana, string descripcion, string nombre, List<List<Ejercicio>> ejercicios)
        {
            Nivel = nivel;
            NumDiasSemana = numDiasSemana;
            Descripcion = descripcion;
            Nombre = nombre;
            ejercicios.ForEach((ejerciciosDia) => Ejercicios.AddRange(ejerciciosDia) );
            
        }

        public Rutina()
        {
            Ejercicios = new List<Ejercicio>();
        }

        public NIVEL Nivel { get => _nivel; set => _nivel = value; }

        [JsonProperty("nivel")]
        public string NivelText
        {
            get
            {
                return Nivel.ToString().ToLower();
            }
            set
            {
                var enumValue = value.ToUpper();
                Nivel = (NIVEL)Enum.Parse(typeof(NIVEL), enumValue);
            }
        }

        [JsonProperty("num_dias_semana")]
        public int NumDiasSemana { get => _numDiasSemana; set => _numDiasSemana = value; }
        [JsonProperty("descripcion")]
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        [JsonProperty("archivada")]
        public bool Archivada { get => _archivada; set => _archivada = value; }
        [JsonProperty("compartida")]
        public bool Compartida { get => _compartida; set => _compartida = value; }
        [JsonProperty("propietario")]
        public Usuario Propietario { get => _propietario; set => _propietario = value; }
        [JsonProperty("nombre")]
        public string Nombre { get => _nombre; set => _nombre = value; }
        [JsonProperty("publicador")]
        public Usuario Publicador { get; set; }

        [JsonProperty("ejercicios")] public List<Ejercicio> Ejercicios { get; set; }

        [JsonIgnore]
        public int TiempoEnMinutos
        {
            get
            {
               
                return 0;
            }
        }

        [JsonProperty("valoracion_media")]
        public int ValoracionMedia { get; set; }
    }
}
