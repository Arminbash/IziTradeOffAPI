using FluentValidation;
using IziTradeOff.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IziTradeOff.Service.Validator
{
    public class TipoPersonaValidator:AbstractValidator<TipoPersonaDto>
    {
        public TipoPersonaValidator()
        {
            RuleFor(x => x.Tipo).NotEmpty();
            RuleFor(x => x.Estado).NotEmpty();
        }
    }
}
