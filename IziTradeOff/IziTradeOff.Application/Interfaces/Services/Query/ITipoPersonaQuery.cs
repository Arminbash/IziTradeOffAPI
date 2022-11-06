using IziTradeOff.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IziTradeOff.Application.Interfaces.Services.Query
{
    public interface ITipoPersonaQuery
    {
        Task<List<TipoPersonaDto>> ListaTipoPersona();
        Task<TipoPersonaDto> ObtenerTipoPersonaXId(int Id);
    }
}
