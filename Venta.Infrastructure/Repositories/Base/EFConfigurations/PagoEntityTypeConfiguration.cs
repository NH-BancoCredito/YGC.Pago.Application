using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Pago.Domain.Models;

namespace Pago.Infrastructure.Repositories.Base.EFConfigurations
{
    public class PagoEntityTypeConfiguration
        : IEntityTypeConfiguration<Pago.Domain.Models.Pago>
    {
        public void Configure(EntityTypeBuilder<Pago.Domain.Models.Pago> builder)
        {
            builder.ToTable("Pago");
            builder.HasKey(c => c.IdPago);
            
        }
    }
}
