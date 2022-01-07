using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FantasyName)
                .IsRequired();

            builder.HasOne(x => x.Address).WithOne(x => x.Supplier);
            builder.HasOne(x => x.Email).WithOne(x => x.Supplier);

            builder.HasMany(x => x.Phones)
               .WithOne(x => x.Supplier)
               .HasForeignKey(x => x.SupplierId);

            builder.ToTable("TB_Supplier");
        }
    }
}
