using System;
using System.Collections.Generic;
using System.Text;

namespace IziTradeOff.Domain
{
    public class TipoCliente : ClaseBase
    {
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// clave forranea del  cliente
        /// </summary>
        public virtual ICollection<Cliente> Cliente { get; set; }

    }
}
