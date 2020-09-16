using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace GymFit.Models
{
    public enum NIVEL_ACTIVIDAD { BAJO, MEDIO, ALTO }
    public enum OBJETIVO { PERDER_GRASA, MANTENIMIENTO, GANAR_MUSCULO }
    public enum MUSCULOS { PECTORAL, ESPALDA, HOMBROS, CUADRICEPS, FEMORALES, BICEPS, TRICEPS, ANTEBRAZO, GLUTEOS, ABDOMINALES, GEMELOS };
    public class Usuario
    {
        private string _username;
        private string _email;
        private string _password;
        private string _primerApellido;
        private string _segundoApellido;
        private string _nombre;
        private string _token;
        private DateTime _tokenValidation;
        private int _altura;
        private NIVEL_ACTIVIDAD _nivelActividad;
        private DateTime _fechaNacimiento;
        private int _rutinaActiva;
        private OBJETIVO _objetivo;
        private double _pesoActual;
        private DateTime _caducidadToken;

        [JsonProperty("username")]
        public string Username { get => _username; set => _username = value; }
        [JsonProperty("token")]
        public string Token { get => _token; set => _token = value; }
        [JsonProperty("altura")]
        public int Altura { get => _altura; set => _altura = value; }
        public NIVEL_ACTIVIDAD NivelActividad { get => _nivelActividad; set => _nivelActividad = value; }
        [JsonProperty("nivel_actividad")]
        public string NivelActividadText
        {
            get
            {
                return NivelActividad.ToString();
            }
            set
            {
                NivelActividad = (NIVEL_ACTIVIDAD)Enum.Parse(typeof(NIVEL_ACTIVIDAD), value);
            }
        }
        public OBJETIVO Objetivo { get => _objetivo; set => _objetivo = value; }

        [JsonProperty("objetivo")]
        public string ObtetivoText
        {
            get
            {
                return Objetivo.ToString();
            }
            set
            {
                Objetivo = (OBJETIVO) Enum.Parse(typeof(OBJETIVO), value);
            }
        }
        [JsonProperty("peso_actual")]
        public double PesoActual { get => _pesoActual; set => _pesoActual = value; }
        [JsonProperty("primer_apellido")]
        public string PrimerApellido { get => _primerApellido; set => _primerApellido = value; }
        [JsonProperty("segundo_apellido")]
        public string SegundoApellido { get => _segundoApellido; set => _segundoApellido = value; }
        [JsonProperty("name")]
        public string Nombre { get => _nombre; set => _nombre = value; }
        [JsonProperty("fecha_nacimiento")]
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        [JsonProperty("email")]
        public string Email { get => _email; set => _email = value; }
        [JsonProperty("caducidad_token")]
        public DateTime CaducidadToken { get => _caducidadToken; set => _caducidadToken = value; }
        [JsonProperty("password")]
        public string Password { get => _password; set => _password = value; }
        [JsonProperty("rutina_activa")]
        public int? RutinaActiva { get => _rutinaActiva;
            set => _rutinaActiva = value ?? -1;
        }
    }
}
