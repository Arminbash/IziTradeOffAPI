using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IziTradeOff.Domain
{
    public class Empleado : ClaseBase
    {

        /// <summary>
        /// codigo que identifica a la persona
        /// </summary>
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        /// <summary>
        /// Fecha ingreso
        /// </summary>
        public DateTime? FechaIngreso { get; set; }
        /// <summary>
        /// nombre del cargo
        /// </summary>
        public string Cargo { get; set; }
        ///<summary>
        /// Numero de licencia
        /// </summary>
        public string NumeroLicencia { get; set; }
        ///<summary>
        /// Foto
        /// </summary>
        public byte Foto { get; set; }
        ///<summary>
        /// propiedad de navegacion de persona
        /// </summary>

        public virtual Persona Persona { get; set; }


    }
}
