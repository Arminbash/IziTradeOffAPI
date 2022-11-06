﻿using IziTradeOff.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IziTradeOff.Application.Interfaces.Services.Query
{
    public interface IPersonaQuery
    {
        

        Task<List<PersonaDto>> ListaPersona();
        Task<PersonaDto> PersonaPorId(int IdPersona);
    }
}
