using GymFit.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Services.Intefaces
{
    public interface IEspecificacionEjerciciosService
    {
        Task<IEnumerable<EspecificacionEjercicio>> GetEspecificacionesEjerciciosByName(string name);
        Task<EspecificacionEjercicio> CrearEspecificacionEjercicio(EspecificacionEjercicio especificacion);

        Task<List<EspecificacionEjercicio>> GetEspecificacionEjercicioByMuscle(MUSCULOS musculo, int numeroEjercicios);

    }
}
