using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Services.Intefaces
{
    using System.Threading.Tasks;
    using Models;

    public interface IEjerciciosService
    {
        Task<Ejercicio> GetEjercicio(int id);

        Task<Registro> AddRegistroToEjercicio(Ejercicio ejercicio, Registro registro);
    }
}
