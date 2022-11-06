using System;
using System.Collections.Generic;
using System.Text;

namespace IziTradeOff.Application.Dtos
{
    public class TipoPersonaDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Tipo de Persona
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
