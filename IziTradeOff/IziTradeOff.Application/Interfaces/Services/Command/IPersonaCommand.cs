using IziTradeOff.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IziTradeOff.Application.Interfaces.Services.Command
{
    public interface IPersonaCommand
    {
        
        Task<PersonaDto> CrearPersona(PersonaDto persona);
      
        Task<PersonaDto> ActulizarPersona(PersonaDto persona);
    }
}
