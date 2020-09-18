using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Models
{

    public enum NIVEL { PRINCIPIANTE, INTERMEDIO, AVANZADO }
    public class Rutina
    {
        private string _nombre;
        private NIVEL _nivel;
        private int _numDiasSemana;
        private string _descripcion;
        private bool _archivada;
        private bool _compartida;
        private List<List<Ejercicio>> _ejerciciosDays;

        public Rutina(NIVEL nivel, int numDiasSemana, string descripcion, string nombre, IEnumerable<Ejercicio> ejercicios)
        {
            Nivel = nivel;
            NumDiasSemana = numDiasSemana;
            Descripcion = descripcion;
            Nombre = nombre;
            Ejercicios = new List<Ejercicio>(ejercicios);
            
        }

        public Rutina()
        {
            Ejercicios = new List<Ejercicio>();
        }

        public NIVEL Nivel { get => _nivel; set => _nivel = value; }


        public int NumDiasSemana { get => _numDiasSemana; set => _numDiasSemana = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool Archivada { get => _archivada; set => _archivada = value; }
        public bool Compartida { get => _compartida; set => _compartida = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public List<Ejercicio> Ejercicios { get; set; }


    }
}
