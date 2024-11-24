using API_Sucursales_Practica.DTOs;
using FluentValidation;

namespace API_Sucursales_Practica.Validators
{
    public class UpdateSucursalDTOValidator : AbstractValidator<UpdateSucursalDTO>
    {
        public UpdateSucursalDTOValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(id => Guid.TryParse(id, out _))
                .WithMessage("El ID debe ser un GUID valido");


            When(x => !string.IsNullOrEmpty(x.IdTipo), () =>
            {
                RuleFor(x => x.IdTipo)
                .Must(idTipo => Guid.TryParse(idTipo, out _))
                .WithMessage("El formato del campo IdTipo debe ser parseable a GUID");
            });

            When(x => !string.IsNullOrEmpty(x.IdProvincia), () =>
            {
                RuleFor(x => x.IdTipo)
                .Must(idTipo => Guid.TryParse(idTipo, out _))
                .WithMessage("El formato del campo IdProvincia debe ser parseable a GUID");
            });




        }
    }
}
