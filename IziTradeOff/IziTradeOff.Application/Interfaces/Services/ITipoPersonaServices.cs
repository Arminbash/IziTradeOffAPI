using IziTradeOff.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace IziTradeOff.Application.Interfaces.Services
{
    public interface ITipoPersonaService
    {
        /// <summary>
        /// Agrega una nueva tipo persona
        /// </summary>
        /// <param name="`tipoPersona">tipoPersona</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<TipoPersonaDto> AddTipoPersonaAsync(TipoPersonaDto tipoPersona);
        /// <summary>
        /// Actualiza el tipo Persona
        /// </summary>
        /// <param name="IdTipoPersona">tipoPersona</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<TipoPersonaDto> UpdateTipoPersonaAsync(TipoPersonaDto tipoPersona);
        /// <summary>
        /// Obtiene todas los tipos Persona en todos 
        /// </summary>
        /// <returns>Obtiene todas los tipos persona</returns>
        /// Francisco Rios
        Task<IReadOnlyList<TipoPersonaDto>> GetAllTipoPersonaAsync();
        /// <summary>
        /// Obtiene el tipo de persona
        /// </summary>
        /// <param name="IdTipoPersona">IdTipoPersona</param>
        /// <returns>Retorna el tipo persona del id/returns>
        /// Francisco Rios
        Task<TipoPersonaDto> GetTipoPersonaPorIdAsync(int IdTipoPersona);
        

    }
}
