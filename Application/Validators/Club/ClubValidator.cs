using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validators.Club
{
    public class ClubValidator: AbstractValidator<ClubRequestDto>
    {
        public ClubValidator() {
            RuleFor(x => x.ClubDes)
                .NotNull().WithMessage("El campo descripcion no puede ser nulo")
                .NotEmpty().WithMessage("El campo no puede ser vacio");
        }
    }
}
