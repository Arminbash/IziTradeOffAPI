using Azure.Core;
using IziTradeOff.Application.Dtos;
using IziTradeOff.Application.Exceptions;
using IziTradeOff.Application.Interfaces.Services;
using IziTradeOff.Application.Interfaces.Services.Query;
using IziTradeOff.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IziTradeOff.Service.Query
{
    public class TipoPersonaQuery : ITipoPersonaQuery
    {

        private readonly ITipoPersonaService tipoPersonaService;
        /// <summary>
        /// constructor para injectar las dependencias
        /// </summary>
        /// <param name="_context">Contexto Base</param>
        /// <param name="_ItipoPersonaService">Service de tipo persona</param>
        /// Francisco Rios
        public  TipoPersonaQuery(ITipoPersonaService _ItipoPersonaService)
        {
            tipoPersonaService = _ItipoPersonaService;
        }
        public async Task<List<TipoPersonaDto>> ListaTipoPersona()
        {
            var query = await tipoPersonaService.GetAllTipoPersonaAsync();
            return query.ToList();
        }
        
        public async Task<TipoPersonaDto> ObtenerTipoPersonaXId(int Id)
        {
            var query = await tipoPersonaService.GetTipoPersonaPorIdAsync(Id);
            if (query == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe la Tipo Persona" });
            }
            return query;
        }
    }
}
