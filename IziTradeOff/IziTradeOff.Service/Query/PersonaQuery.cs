using IziTradeOff.Application.Dtos;
using IziTradeOff.Application.Exceptions;
using IziTradeOff.Application.Interfaces.Services;
using IziTradeOff.Application.Interfaces.Services.Command;
using IziTradeOff.Application.Interfaces.Services.Query;
using IziTradeOff.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IziTradeOff.Service.Query
{
    public class PersonaQuery : IPersonaQuery
    {
        private readonly IPersonaService PersonaService;
        /// <summary>
        /// constructor para injectar las dependencias
        /// </summary>
        /// <param name="_context">Contexto Base</param>
        /// <param name="_IPersonaService">Service de persona</param>
        /// Francisco Rios
        public PersonaQuery(IPersonaService _IPersonaService)
        {
            PersonaService = _IPersonaService;
        }
        public async Task<List<PersonaDto>> ListaPersona()
        {
            var query = await PersonaService.GetAllPersonaAsync();
            return query.ToList();
        }

        public async Task<PersonaDto> PersonaPorId(int IdPersona)
        {
            var query = await PersonaService.GetPersonaPorIdAsync(IdPersona);
            if (query == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe la Tipo Persona" });
            }
            return query;
        }
    }
}
