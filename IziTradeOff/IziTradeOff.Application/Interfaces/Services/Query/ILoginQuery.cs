using IziTradeOff.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IziTradeOff.Application.Interfaces.Services.Query
{
    public interface ILoginQuery
    {
      
        Task<UsuarioDto> UsuarioActual();
    }
}
