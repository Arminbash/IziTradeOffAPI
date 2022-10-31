using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;

namespace IziTradeOff.Application.Interfaces.Services.Command
{
    public interface IRolCommand
    {
       Task<IdentityRole> RolNuevo(string Nombre);
       Task<IdentityRole> RolEliminar(string Nombre);
       Task<IdentityRole> UsuarioRolAgregar(string userName, string RolName);
       Task<IdentityRole> UsuarioRolEliminar(string userName, string RolName);
    }
}
