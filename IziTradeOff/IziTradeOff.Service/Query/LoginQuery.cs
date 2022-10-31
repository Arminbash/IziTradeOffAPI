using IziTradeOff.Application.Exceptions;
using IziTradeOff.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using IziTradeOff.Persistence.Connection;
using Microsoft.EntityFrameworkCore;
using IziTradeOff.Application.Interfaces;
using IziTradeOff.Application.Dtos;
using IziTradeOff.Application.Interfaces.Services.Query;

namespace IziTradeOff.Service.Query
{
    public class LoginQuery : ILoginQuery
    {
        #region "Variables Globales"
        private readonly UserManager<Usuario> userManager;
        private readonly IConexion context;
        private readonly IUsuarioHelper _usuarioSesion;
        private readonly IJwtGenerador _jwtGenerador;
        #endregion


        public LoginQuery(UserManager<Usuario> _userManager, IConexion _context, IUsuarioHelper usuarioSesion, IJwtGenerador jwtGenerador)
        {
            userManager = _userManager;
            context = _context;
            _usuarioSesion = usuarioSesion;
            _jwtGenerador = jwtGenerador;
        }
       

        /// <summary>
        /// Metodo que obtiene el usuario actual
        /// </summary>
        public async Task<UsuarioDto> UsuarioActual()
        {
            var usuario = await userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            var resultadoRoles = await userManager.GetRolesAsync(usuario);
            var listaRoles = new List<string>(resultadoRoles);

            return new UsuarioDto
            {
                NombreCompleto = usuario.NombreCompleto,
                UserName = usuario.UserName,
                Token = _jwtGenerador.CrearToken(usuario, listaRoles),
                Imagen = null,
                Email = usuario.Email
            };
        }
    }
}
