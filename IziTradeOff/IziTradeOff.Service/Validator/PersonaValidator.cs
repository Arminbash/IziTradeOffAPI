using FluentValidation;
using IziTradeOff.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IziTradeOff.Service.Validator
{
    public class PersonaValidator : AbstractValidator<PersonaDto>
    {
        public PersonaValidator()
        {
            RuleFor(x => x.PrimerNombre).NotEmpty();
            RuleFor(x => x.SegundoNombre).NotEmpty();
            RuleFor(x => x.PrimerApellido).NotEmpty();
            RuleFor(x => x.SegundoApellido).NotEmpty();
            RuleFor(x => x.Correo).NotEmpty();
            RuleFor(x => x.Cedula).NotEmpty();
            RuleFor(x => x.Direccion).NotEmpty();
            RuleFor(x => x.Telefono).NotEmpty();
            RuleFor(x => x.TipoPersonaId).NotEmpty();
        }
    }
}
