using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using IziTradeOff.Application.Dtos;

namespace IziTradeOff.Application.Interfaces.Services.Command
{
    public interface ITipoPersonaCommand
    {
        Task<TipoPersonaDto> CrearTipoPersona(TipoPersonaDto tipoPersona);
        Task<TipoPersonaDto> ActualizarTipoPersona(TipoPersonaDto tipoPersona);
    }
}
