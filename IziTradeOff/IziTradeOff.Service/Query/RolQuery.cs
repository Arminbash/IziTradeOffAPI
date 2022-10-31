using IziTradeOff.Application.Exceptions;
using IziTradeOff.Application.Interfaces.Services.Query;
using IziTradeOff.Domain;
using IziTradeOff.Persistence.Connection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IziTradeOff.Service.Query
{
    public class RolQuery : IRolQuery
    {

        #region "Variables Globales"
        private readonly UserManager<Usuario> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConexion context;
        #endregion
        public RolQuery(UserManager<Usuario> _userManager, RoleManager<IdentityRole> _roleManager, IConexion _context)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            context = _context;
        }
        public async Task<List<IdentityRole>> ListaRoles()
        {
            var roles = await context.Roles.ToListAsync();

            return roles;
        }
        /// <summary>
        /// Metodo que sirve para obtener  los roles por usuario
        /// </summary>
        public async Task<List<string>> ObtenerRolesPorUsuario(string userName)
        {
            var usuarioIden = await userManager.FindByNameAsync(userName);
            if (usuarioIden == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el Usuario" });
            }

            var resultado = await userManager.GetRolesAsync(usuarioIden);
            return new List<string>(resultado);

        }
    }
}
