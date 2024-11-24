using API_Sucursales_Practica.DTOs;
using FluentValidation;

namespace API_Sucursales_Practica.Validators
{
    public class CreateSucursalDTOValidator : AbstractValidator<CreateSucursalDTO>
    {
        public CreateSucursalDTOValidator()
        {
            RuleFor(x => x.IdTipo)
                .Must(idTipo => Guid.TryParse(idTipo, out _))
                .WithMessage("El formato del campo IdTipo debe ser parseable a Guid")
                .NotEmpty();

            RuleFor(x=> x.IdProvincia)
                .Must(idProvincia => Guid.TryParse(idProvincia, out _))
                .WithMessage("El formato del campo debe ser parseable a Guid")
                .NotEmpty();    
        }
    }
}
