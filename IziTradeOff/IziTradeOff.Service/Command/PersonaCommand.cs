using Azure.Core;
using IziTradeOff.Application.Dtos;
using IziTradeOff.Application.Exceptions;
using IziTradeOff.Application.Interfaces.Services;
using IziTradeOff.Application.Interfaces.Services.Command;
using IziTradeOff.Service.Services;
using IziTradeOff.Service.Validator;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IziTradeOff.Service.Command
{
    public class PersonaCommand : IPersonaCommand
    {
        private readonly IPersonaService PersonaService;
        /// <summary>
        /// constructor para injectar las dependencias
        /// </summary>
        /// <param name="_PersonaService">Service de  persona</param
        /// Francisco Rios
        public PersonaCommand(IPersonaService _PersonaService)
        {
            PersonaService = _PersonaService;

        }
        public async Task<PersonaDto> ActulizarPersona(PersonaDto parametros)
        {
            var query = await PersonaService.GetPersonaPorIdAsync(parametros.Id);
            if (query == null)
            {
                throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Persona no encontrada" });
            }

            var UpdateQuery = new PersonaDto
            {
                Id = parametros.Id,
                PrimerNombre = parametros.PrimerNombre ?? query.PrimerNombre,
                SegundoNombre = parametros.SegundoNombre ?? query.SegundoNombre,
                PrimerApellido = parametros.PrimerApellido ?? query.PrimerApellido,
                SegundoApellido = parametros.SegundoApellido ?? query.SegundoApellido,
                Correo = parametros.Correo ?? query.Correo,
                Cedula = parametros.Cedula ?? query.Cedula,
                Direccion = parametros.Direccion ?? query.Direccion,
                Telefono = parametros.Telefono,
                TipoPersonaId = parametros.TipoPersonaId,
                Estado = parametros.Estado
            };
            var valor = await PersonaService.UpdatePersonaAsync(UpdateQuery);
            if (valor != null)
            {
                return valor;
            }
            throw new Exception("error al actualizar");
        }

        public async Task<PersonaDto> CrearPersona(PersonaDto  parametros)
        {
            PersonaValidator validator = new PersonaValidator();
            var results = validator.Validate(parametros);

            if (!results.IsValid)
            {
                throw new Application.Exceptions.ValidationException(results.GeneratetDictionary());
            }

            var valor = await PersonaService.AddPersonaAsync(parametros);
            if (valor != null)
            {
                return valor;
            }
            throw new Exception("Error al crear el tipo persona");
        }
    }
}
