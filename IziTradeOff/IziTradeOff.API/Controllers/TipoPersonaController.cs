using IziTradeOff.Application.Dtos;
using IziTradeOff.Application.Interfaces.Services.Command;
using IziTradeOff.Application.Interfaces.Services.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IziTradeOff.API.Controllers
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de tipo persona
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoPersonaController : ApiControllerBase
    {
        private ITipoPersonaCommand _ITipoPersonaCommand;
        private ITipoPersonaQuery _ITipoPersonaQuery;
        public TipoPersonaController(ITipoPersonaCommand ITipoPersonaCommand, ITipoPersonaQuery iTipoPersonaQuery)
        {
            _ITipoPersonaCommand = ITipoPersonaCommand;
            _ITipoPersonaQuery = iTipoPersonaQuery;
        }
        /// <summary>
        /// EndPoint encargado de crear un nuevo tipo persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/CreateTipoPersona
        [HttpPost("CrearTipoPersona")]
        public async Task<ActionResult<TipoPersonaDto>> CreateTipoPersona(TipoPersonaDto parametros)
        {
            return await _ITipoPersonaCommand.CrearTipoPersona(parametros);
        }
        /// <summary>
        /// EndPoint encargado de Editar un tipo de persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/UpdatetipoPersona
        [HttpPut("ActualizarTipoPersona")]
        public async Task<ActionResult<TipoPersonaDto>> UpdateTipoPersona(TipoPersonaDto tipoPersonaDto)
        {
            return await _ITipoPersonaCommand.ActualizarTipoPersona(tipoPersonaDto);
        }
        /// <summary>
        /// EndPoint encargado de listar Tipo Persona
        /// </summary>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerTipoPersona
        [HttpGet("ListaTipoPersona")]
        public async Task<ActionResult<List<TipoPersonaDto>>> GetTipoPersona()
        {
            return await _ITipoPersonaQuery.ListaTipoPersona();
        }
        /// <summary>
        /// EndPoint encargado de buscar un Tipo Persona por Id
        /// </summary>
        /// <param name="id">Id del tipo persona</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerTipoPersona/Id
        [HttpGet("ObtenerTipoPersonaPorId/{id}")]
        public async Task<ActionResult<TipoPersonaDto>> GetTipoPersonaXId(int id)
        {
            return await _ITipoPersonaQuery.ObtenerTipoPersonaXId(id);
        }
    }
}
