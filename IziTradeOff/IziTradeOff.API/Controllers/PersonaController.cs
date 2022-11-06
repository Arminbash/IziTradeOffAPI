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
    /// Controller que se encarga de la manipulacion de persona
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : ApiControllerBase
    {
        private IPersonaCommand _IPersonaCommand;
        private IPersonaQuery _IPersonaQuery;
        public PersonaController(IPersonaCommand IPersonaCommand, IPersonaQuery IPersonaQuery)
        {
            _IPersonaCommand = IPersonaCommand;
            _IPersonaQuery = IPersonaQuery;
        }
        /// <summary>
        /// EndPoint encargado de crear a una persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/persona/CreatePersona
        [HttpPost("CrearPersona")]
        public async Task<ActionResult<PersonaDto>> CrearPersona(PersonaDto parametros)
        {
            return await _IPersonaCommand.CrearPersona(parametros);
        }
        /// <summary>
        /// EndPoint encargado de una persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/persona/UpdatePersona
        [HttpPut("ActualizarPersona")]
        public async Task<ActionResult<PersonaDto>> ActualizarPersona(PersonaDto parametros)
        {
            return await _IPersonaCommand.ActulizarPersona(parametros);
        }
        /// <summary>
        /// EndPoint encargado de listar  Persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/persona/ObtenerPersona
        [HttpGet("ListaPersona")]
        public async Task<ActionResult<List<PersonaDto>>> ListaPersona()
        {
            return await _IPersonaQuery.ListaPersona();
        }
        /// <summary>
        /// EndPoint encargado de buscar una  Persona por Id
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/persona/ObtenerPersona
        [HttpGet("ObtenerPersona/{id}")]
        public async Task<ActionResult<PersonaDto>> ObtenerPersonaXId(int id)
        {
            return await _IPersonaQuery.PersonaPorId(id);
        }
    }
}
