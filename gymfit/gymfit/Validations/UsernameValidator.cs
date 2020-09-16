using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Validations
{
    using System.Runtime.CompilerServices;
    using FluentValidation;
    using Services;
    using Services.Interfaces;

    public class UsernameValidator : AbstractValidator<string>
    {
        private IUsuarioService _usuarioService;
        public UsernameValidator(IUsuarioService usuarioService)
        {
            RuleFor((username) => username).NotNull().NotEmpty()
                .WithMessage("El nombre de usuario no puede estar vacio");
        }

        private async Task<bool> IsAvailableUsername(string username)
        {
            return await _usuarioService.IsAvailableUsername(username);
        }
    }
}
