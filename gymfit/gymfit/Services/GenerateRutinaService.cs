using GymFit.Models;
using GymFit.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Services
{
    public class GenerateRutinaService : IGenerateRutinasService
    {

        private IEspecificacionEjerciciosService _especificacionEjerciciosService;


        public GenerateRutinaService(IEspecificacionEjerciciosService especificacionEjerciciosService)
        {
            _especificacionEjerciciosService = especificacionEjerciciosService;
        }
        public async Task<Rutina> GenerateRutinaAsync(int numDias, NIVEL nivel, List<MUSCULOS> musculosExcluidos)
        {
            switch (nivel)
            {
                case NIVEL.PRINCIPIANTE: return await GenerarRutinaPrincipiante(numDias, musculosExcluidos);
              
                case NIVEL.INTERMEDIO: return await GenerarRutinaIntermedio(numDias, musculosExcluidos);
                 
                case NIVEL.AVANZADO: return await GenerarRutinaAvanzado(numDias, musculosExcluidos);
            }
            return null;
        }

        private async Task<Rutina> GenerarRutinaAvanzado(int numDias, List<MUSCULOS> musculosExcluidos)
        {
            if(numDias == 6)
            {
                return await GenerarRutinaWeider(musculosExcluidos);
            }
            else
            {
                return await GenerarRutinaTorsoPiernaAvanzado(musculosExcluidos);
            }
        }

        private async Task<Rutina> GenerarRutinaTorsoPiernaAvanzado(List<MUSCULOS> musculosExcluidos)
        {
            List<MUSCULOS> musculosTorso = new List<MUSCULOS>()
            {
               MUSCULOS.ESPALDA, MUSCULOS.HOMBROS, MUSCULOS.PECTORAL, MUSCULOS.BICEPS, MUSCULOS.TRICEPS
            };

            List<MUSCULOS> musculosPierna = new List<MUSCULOS>()
            {
                MUSCULOS.CUADRICEPS, MUSCULOS.GLUTEOS, MUSCULOS.FEMORALES, MUSCULOS.GEMELOS
            };

            ExcluirMusculos(ref musculosTorso, musculosExcluidos);
            ExcluirMusculos(ref musculosPierna, musculosExcluidos);

            List<EspecificacionEjercicio> especificacionEjerciciosTorso = new List<EspecificacionEjercicio>();
            foreach (var musculo in musculosTorso)
            {
                var especificaciones = await _especificacionEjerciciosService.GetEspecificacionEjercicioByMuscle(musculo, 2);
                if (especificaciones.Count > 0)
                    especificacionEjerciciosTorso.AddRange(especificaciones);
            }

            LimpiarEjercicios(ref especificacionEjerciciosTorso, musculosExcluidos);

            List<EspecificacionEjercicio> especificacionEjerciciosPierna = new List<EspecificacionEjercicio>();
            foreach (var musculo in musculosPierna)
            {
                var especificaciones = await _especificacionEjerciciosService.GetEspecificacionEjercicioByMuscle(musculo, 2);
                if (especificaciones.Count > 0)
                    especificacionEjerciciosPierna.AddRange(especificaciones);
            }

            LimpiarEjercicios(ref especificacionEjerciciosPierna, musculosExcluidos);

            List<Ejercicio> ejerciciosTorso = new List<Ejercicio>();
            foreach (var especificacion in especificacionEjerciciosTorso)
            {
                ejerciciosTorso.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 1,
                    NumerosRepeticiones = new List<int>() { 12, 12, 12, 12, 12 }
                });
                ejerciciosTorso.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 3,
                    NumerosRepeticiones = new List<int>() { 12, 12, 12, 12, 12 }
                });
            }

            List<Ejercicio> ejerciciosPierna = new List<Ejercicio>();
            foreach (var especificacion in especificacionEjerciciosPierna)
            {
                ejerciciosPierna.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 2,
                    NumerosRepeticiones = new List<int>() { 12, 12, 12, 12, 12 }
                });

                ejerciciosPierna.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 4,
                    NumerosRepeticiones = new List<int>() { 12, 12, 12, 12, 12 }
                });
            }

            var rutina = new Rutina(NIVEL.AVANZADO, 3, "Rutina torso pierna de nivel avanzado", "Rutina Torso Pierna", ejerciciosTorso.Union(ejerciciosPierna));

            return rutina;
        }

        private async Task<Rutina> GenerarRutinaWeider(List<MUSCULOS> musculosExcluidos)
        {
            var dia1 = await GetEjerciciosWeider(MUSCULOS.PECTORAL, musculosExcluidos, 1);
            var dia2 = await GetEjerciciosWeider(MUSCULOS.ESPALDA, musculosExcluidos, 2);
            var dia4 = await GetEjerciciosWeider(MUSCULOS.TRICEPS, musculosExcluidos, 4);
            var dia5 = await GetEjerciciosWeider(MUSCULOS.BICEPS, musculosExcluidos, 5);
            var dia6 = await GetEjerciciosWeider(MUSCULOS.HOMBROS, musculosExcluidos, 6);

            var dia3 = new List<Ejercicio>();
            var musculosPierna = new List<MUSCULOS>() { MUSCULOS.CUADRICEPS, MUSCULOS.FEMORALES, MUSCULOS.GEMELOS };
            foreach(var musculo in musculosPierna)
            {
                var especificaciones = await _especificacionEjerciciosService.GetEspecificacionEjercicioByMuscle(musculo, 2);
                LimpiarEjercicios(ref especificaciones, musculosExcluidos);
                if (especificaciones.Count > 0)
                    especificaciones.ForEach((especificacion) => dia3.Add(new Ejercicio() { Especificacion = especificacion, IndexDay = 3,NumerosRepeticiones = new List<int>() { 12, 10, 8 } }));
            }

            
            var rutina = new Rutina(NIVEL.AVANZADO, 6, "Rutina weider de nivel avanzado", "Rutina Weider", dia1.Union(dia2).Union(dia3).Union(dia4).Union(dia5).Union(dia6));

            return rutina;

        }

        private async Task<List<Ejercicio>> GetEjerciciosWeider(MUSCULOS musculo, List<MUSCULOS> excluidos, int day)
        {
            var ejercicios = new List<Ejercicio>();
            var especificacionesDia = new List<EspecificacionEjercicio>();
            especificacionesDia = await _especificacionEjerciciosService.GetEspecificacionEjercicioByMuscle(musculo, 5);
            LimpiarEjercicios(ref especificacionesDia, excluidos);
            especificacionesDia.ForEach((especificacion) => ejercicios.Add(new Ejercicio()
            {
                Especificacion = especificacion,
                IndexDay = day,
                NumerosRepeticiones = new List<int>() { 12, 10, 8 }
            }));
            return ejercicios;
        }

        private async Task<Rutina> GenerarRutinaIntermedio(int numDias, List<MUSCULOS> musculosExcluidos)
        {
            if(numDias == 3)
            {
                return await GenerarRutinaFullbodyIntermedio(musculosExcluidos);
            }
            else
            {
                return await GenerarTorsoPiernaIntermedio(musculosExcluidos);
            }
        }

        private async Task<Rutina> GenerarTorsoPiernaIntermedio(List<MUSCULOS> musculosExcluidos)
        {
            List<MUSCULOS> musculosTorso = new List<MUSCULOS>()
            {
               MUSCULOS.ESPALDA, MUSCULOS.HOMBROS, MUSCULOS.PECTORAL, MUSCULOS.BICEPS, MUSCULOS.TRICEPS
            };

            List<MUSCULOS> musculosPierna = new List<MUSCULOS>()
            {
                MUSCULOS.CUADRICEPS, MUSCULOS.GLUTEOS, MUSCULOS.FEMORALES, MUSCULOS.GEMELOS
            };

            ExcluirMusculos(ref musculosTorso, musculosExcluidos);
            ExcluirMusculos(ref musculosPierna, musculosExcluidos);

            List<EspecificacionEjercicio> especificacionEjerciciosTorso = new List<EspecificacionEjercicio>();
            foreach (var musculo in musculosTorso)
            {
                var especificaciones = await _especificacionEjerciciosService.GetEspecificacionEjercicioByMuscle(musculo, 2);
                if (especificaciones.Count > 0)
                    especificacionEjerciciosTorso.AddRange(especificaciones);
            }

            LimpiarEjercicios(ref especificacionEjerciciosTorso, musculosExcluidos);

            List<EspecificacionEjercicio> especificacionEjerciciosPierna = new List<EspecificacionEjercicio>();
            foreach (var musculo in musculosPierna)
            {
                var especificaciones = await _especificacionEjerciciosService.GetEspecificacionEjercicioByMuscle(musculo, 2);
                if (especificaciones.Count > 0)
                    especificacionEjerciciosPierna.AddRange(especificaciones);
            }
            LimpiarEjercicios(ref especificacionEjerciciosPierna, musculosExcluidos);

            List<Ejercicio> ejerciciosTorso = new List<Ejercicio>();
            foreach (var especificacion in especificacionEjerciciosTorso)
            {
                ejerciciosTorso.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 1,
                    NumerosRepeticiones = new List<int>() { 12, 12, 12, 12 }
                });
                ejerciciosTorso.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 3,
                    NumerosRepeticiones = new List<int>() { 12, 12, 12, 12 }
                });
            }

            List<Ejercicio> ejerciciosPierna = new List<Ejercicio>();
            foreach (var especificacion in especificacionEjerciciosPierna)
            {
                ejerciciosPierna.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 2,
                    NumerosRepeticiones = new List<int>() { 12, 12, 12, 12 }
                });

                ejerciciosPierna.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 4,
                    NumerosRepeticiones = new List<int>() { 12, 12, 12, 12 }
                });
            }


            var rutina = new Rutina(NIVEL.INTERMEDIO, 4, "Rutina torso pierna de nivel intermedio", "Rutina Torso Pierna", ejerciciosTorso.Union(ejerciciosPierna));

            return rutina;

        }

        private void LimpiarEjercicios(ref List<EspecificacionEjercicio> ejercicios, List<MUSCULOS> musculosExcluidos)
        {
            var deleteItems = new List<EspecificacionEjercicio>();
            foreach(var musculo in musculosExcluidos)
            {
                foreach(var ejercicio in ejercicios)
                {
                    if (ejercicio.MusculosSecundarios != null && ejercicio.MusculosSecundarios.Contains(musculo))
                    {
                        deleteItems.Add(ejercicio);
                    }
                }
            }

            foreach(var ejercicio in deleteItems)
            {
                ejercicios.Remove(ejercicio);
            }
        }

        private async Task<Rutina> GenerarRutinaFullbodyIntermedio(List<MUSCULOS> musculosExcluidos)
        {
            List<MUSCULOS> musculos = new List<MUSCULOS>()
            {
                MUSCULOS.CUADRICEPS, MUSCULOS.ESPALDA, MUSCULOS.HOMBROS, MUSCULOS.PECTORAL, MUSCULOS.BICEPS, MUSCULOS.TRICEPS, MUSCULOS.ABDOMINALES, MUSCULOS.ABDOMINALES
            };

            ExcluirMusculos(ref musculos, musculosExcluidos);


            List<EspecificacionEjercicio> especificacionEjercicios = new List<EspecificacionEjercicio>();
            foreach (var musculo in musculos)
            {
                var especificaciones = await _especificacionEjerciciosService.GetEspecificacionEjercicioByMuscle(musculo, 1);
                if (especificaciones.Count > 0)
                    especificacionEjercicios.Add(especificaciones[0]);
            }

            LimpiarEjercicios(ref especificacionEjercicios, musculosExcluidos);

            List<Ejercicio> ejercicios = new List<Ejercicio>();
            foreach (var especificacion in especificacionEjercicios)
            {
                ejercicios.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 1,
                    NumerosRepeticiones = new List<int>() { 12, 10, 8, 6 }
                });

                ejercicios.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 2,
                    NumerosRepeticiones = new List<int>() { 12, 10, 8, 6 }
                });

                ejercicios.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 3,
                    NumerosRepeticiones = new List<int>() { 12, 10, 8, 6 }
                });
            }

            var rutina = new Rutina(NIVEL.INTERMEDIO, 3, "Rutina fullbody de nivel intermedio", "Rutina Fullbody", ejercicios);

            return rutina;
        }

        private async Task<Rutina> GenerarRutinaPrincipiante(int numDias, List<MUSCULOS> musculosExcluidos)
        {
            return await GenerarRutinaFullbodyPrincipiante(musculosExcluidos);
        }

        private async Task<Rutina> GenerarRutinaFullbodyPrincipiante(List<MUSCULOS> musculosExcluidos)
        {
            List<MUSCULOS> musculos = new List<MUSCULOS>()
            {
                MUSCULOS.CUADRICEPS, MUSCULOS.ESPALDA, MUSCULOS.HOMBROS, MUSCULOS.PECTORAL, MUSCULOS.BICEPS, MUSCULOS.TRICEPS, MUSCULOS.ABDOMINALES, MUSCULOS.ABDOMINALES
            };

            ExcluirMusculos(ref musculos, musculosExcluidos);


            List<EspecificacionEjercicio> especificacionEjercicios = new List<EspecificacionEjercicio>();
            foreach(var musculo in musculos)
            {
                var especificaciones = await _especificacionEjerciciosService.GetEspecificacionEjercicioByMuscle(musculo, 1);
                if (especificaciones.Count > 0)
                    especificacionEjercicios.Add(especificaciones[0]);
            }

            LimpiarEjercicios(ref especificacionEjercicios, musculosExcluidos);

            List<Ejercicio> ejercicios = new List<Ejercicio>();
            foreach(var especificacion in especificacionEjercicios)
            {
                ejercicios.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 1,
                    NumerosRepeticiones = new List<int>() { 12, 10, 8 }
                });

                ejercicios.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 2,
                    NumerosRepeticiones = new List<int>() { 12, 10, 8 }
                });

                ejercicios.Add(new Ejercicio()
                {
                    Especificacion = especificacion,
                    IndexDay = 3,
                    NumerosRepeticiones = new List<int>() { 12, 10, 8 }
                });
            }

            var rutina = new Rutina(NIVEL.PRINCIPIANTE, 3, "Rutina fullbody de iniciación", "Rutina Fullbody", ejercicios);

            return rutina;

        }

        private void ExcluirMusculos(ref List<MUSCULOS> musculos, List<MUSCULOS> musculosExcluidos)
        {
            foreach(var musculo in musculosExcluidos)
            {
                musculos.Remove(musculo);
            }
        }

    }
}
