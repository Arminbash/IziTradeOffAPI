using IziTradeOff.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IziTradeOff.Persistence.FluentApi
{
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
    {
        /// <summary>
        /// Configuracion del modelo
        /// </summary>
        /// <param name="builder">Configuracion de la entidad</param>
        /// Francisco Rios
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.Tipo)
                .IsRequired();
            builder.Property(b => b.Estado).HasColumnType("bit");
        }
    }
}
