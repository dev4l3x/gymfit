using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Models
{
    public class EspecificacionEntrenamiento
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private int _neat;

        [JsonProperty("id")]
        public int Id { get => _id; set => _id = value; }
        [JsonProperty("nombre")]
        public string Nombre { get => _nombre; set => _nombre = value; }
        [JsonProperty("descripcion")]
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        [JsonProperty("neat")]
        public int Neat { get => _neat; set => _neat = value; }
    }
}
