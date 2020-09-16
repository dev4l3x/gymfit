using GymFit.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Services.Interfaces
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Loguea a un usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Devuelve el usuario si exite, o null en caso contrario</returns>
        Task<Usuario> Login(string username, string password);

        /// <summary>
        /// Registra a un usuario y le establece un token al usuario
        /// </summary>
        /// <param name="user">Usuario a registrar</param>
        Task<bool> RegisterUsuario(Usuario user);

        /// <summary>
        /// Comprueba si esta disponible un nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario a comprobar si existe</param>
        /// <returns>True si no existe, false en otro caso</returns>
        Task<bool> IsAvailableUsername(string username);

        /// <summary>
        /// Comprueba si existe un email
        /// </summary>
        /// <param name="email">Email a comprobar</param>
        /// <returns>True si existe, false en otro caso</returns>
        Task<bool> ExistsEmail(string email);

        /// <summary>
        /// Obiene el peso del usuario logueado
        /// </summary>
        /// <returns></returns>
        Task<double> GetPeso();


        Task UpdateObjetivo(OBJETIVO nuevoObjetivo);

        Task UpdateNivelActividad(NIVEL_ACTIVIDAD nuevoNivelActividad);

        Task<Usuario> GetCurrentUser();

    }
}
