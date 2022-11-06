using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IziTradeOff.Domain
{
    public class Cliente : ClaseBase
    {
        /// <summary>
        /// clave forena de persona
        /// </summary>
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
        [ForeignKey("TipoCliente")]
        public int TipoClienteId { get; set; }

        /// <summary>
        /// Propiedad de navegacion de persona
        /// </summary>
        public virtual Persona Persona { get; set; }
        /// <summary>
        /// Propiedad de navegacion del tipo cliente
        /// </summary>
        public virtual TipoCliente TipoCliente { get; set; }


    }
}
