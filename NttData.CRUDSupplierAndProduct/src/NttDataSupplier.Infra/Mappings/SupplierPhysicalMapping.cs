using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class SupplierPhysicalMapping : IEntityTypeConfiguration<SupplierPhysical>
    {
        public void Configure(EntityTypeBuilder<SupplierPhysical> builder)
        {            
            

            builder.Property(x => x.Cpf)
                
                .HasColumnType("varchar(12)");
        }
    }
}
