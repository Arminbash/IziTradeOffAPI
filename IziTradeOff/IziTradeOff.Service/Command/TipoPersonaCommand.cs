using FluentValidation;
using IziTradeOff.Application.Dtos;
using IziTradeOff.Application.Exceptions;
using IziTradeOff.Application.Interfaces.Services;
using IziTradeOff.Application.Interfaces.Services.Command;
using IziTradeOff.Service.Validator;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IziTradeOff.Service.Command
{
    public class TipoPersonaCommand : ITipoPersonaCommand
    {


        private readonly ITipoPersonaService tipoPersonaService;

        /// <summary>
        /// constructor para injectar las dependencias
        /// </summary>
        /// <param name="_tipoPersonaService">Service de tipo persona</param
        /// Francisco Rios
        public TipoPersonaCommand(ITipoPersonaService _tipoPersonaService)
        {
            tipoPersonaService = _tipoPersonaService;

        }
        public async Task<TipoPersonaDto> CrearTipoPersona(TipoPersonaDto tipoPersonaDto)
        {
            TipoPersonaValidator validator = new TipoPersonaValidator();
            var results = validator.Validate(tipoPersonaDto);

            if (!results.IsValid)
            {
                throw new Application.Exceptions.ValidationException(results.GeneratetDictionary());
            }

            var valor = await tipoPersonaService.AddTipoPersonaAsync(tipoPersonaDto);
            if (valor != null)
            {
                return valor;
            }
            throw new Exception("Error al crear el tipo persona");
        }
        public async Task<TipoPersonaDto> ActualizarTipoPersona(TipoPersonaDto parametros)
        {
            var query = await tipoPersonaService.GetTipoPersonaPorIdAsync(parametros.Id);
            if (query == null)
            {
                throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Error al editar el tipo persona" });
            }

            var UpdateQuery = new TipoPersonaDto
            {
                Id = query.Id,
                Tipo = parametros.Tipo,
                Estado = parametros.Estado
            };

            var valor = await tipoPersonaService.UpdateTipoPersonaAsync(UpdateQuery);
            if (valor != null)
            {
                return valor;
            }
            throw new Exception("Error al actualizar");
        }
    }
}
