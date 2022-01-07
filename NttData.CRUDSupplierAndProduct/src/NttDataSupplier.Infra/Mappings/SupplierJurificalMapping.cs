using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class SupplierJurificalMapping : IEntityTypeConfiguration<SupplierJuriDical>
    {
        public void Configure(EntityTypeBuilder<SupplierJuriDical> builder)
        {
            builder.Property(x => x.CompanyName)
                .IsRequired();
           

            builder.Property(x => x.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");
        }
    }
}
