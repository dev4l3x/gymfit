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
    }

    public class MockRutinasService : IRutinasService
    {
        public async Task<Rutina> AddRutina(Rutina rutina)
        {
            return new Rutina();
        }

        public async Task<bool> DeleteRutina(Rutina rutina)
        {
            return true;
        }

        public async Task<IEnumerable<Rutina>> GetRutinasOfLoggedUser()
        {
            return new List<Rutina>()
            {
                new Rutina(NIVEL.INTERMEDIO, 3, "Prueba", "Rutina de prueba", new List<Ejercicio>())
            };
            //return new List<Rutina>();
        }

        public async Task MarcarComoActiva(Rutina rutina)
        {
            Console.WriteLine("Rutina marcada como activa");
        }
    }
}
