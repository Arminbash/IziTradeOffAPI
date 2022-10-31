using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;

namespace IziTradeOff.Application.Interfaces.Services.Query
{
    public interface IRolQuery
    {
        Task<List<string>> ObtenerRolesPorUsuario(string userName);
        Task<List<IdentityRole>> ListaRoles();
    }
}
