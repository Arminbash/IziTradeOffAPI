using System;
using System.Collections.Generic;
using System.Text;

namespace IziTradeOff.Domain
{
    public class TipoPersona : ClaseBase
    {

        /// <summary>
        /// Tipo de Persona
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// clave forranea del  persona
        /// </summary>
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
