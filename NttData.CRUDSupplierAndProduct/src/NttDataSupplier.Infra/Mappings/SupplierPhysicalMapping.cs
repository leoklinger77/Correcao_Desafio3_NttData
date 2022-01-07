using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class SupplierPhysicalMapping : IEntityTypeConfiguration<SupplierPhysical>
    {
        public void Configure(EntityTypeBuilder<SupplierPhysical> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired();
            

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("varchar(12)");
        }
    }
}
