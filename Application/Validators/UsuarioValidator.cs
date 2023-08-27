using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioCreateDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Apellidos)
                .NotEmpty().WithMessage("El campo Apellido no puede ser vacio")
                .NotNull().WithMessage("El campo Apellido no puede ser nulo");
            RuleFor(x => x.Nombres)
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacio")
                .NotNull().WithMessage("El campo Nombre no puede ser nulo");


        }
    }
}
