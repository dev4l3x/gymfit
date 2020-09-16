using GymFit.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Services.Interfaces
{
    public interface IRutinasService
    {
        Task<IEnumerable<Rutina>> GetRutinasOfLoggedUser();

        //Task<List<List<Ejercicio>>> GetEjerciciosRutina(int idRutina);

        Task<Rutina> AddRutina(Rutina rutina);

        Task<bool> DeleteRutina(Rutina rutina);

        Task MarcarComoActiva(Rutina rutina);

        Task<Rutina> CompartirRutina(Rutina rutina);

        Task<IEnumerable<Rutina>> GetRutinasCompartidas();
        Task<IEnumerable<Rutina>> GetRutinasPopulares();
        Task<IEnumerable<Rutina>> GetRutinasRecientes();
        Task<IEnumerable<Rutina>> GetRutinasByName(string name);

        Task ObtenerRutina(Rutina rutina);
        Task ValorarRutina(Rutina rutina, int valoracion);
        Task<bool> CanValorarRutina(Rutina rutina);
    }
}
