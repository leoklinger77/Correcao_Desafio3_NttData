using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Images)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.ProductId);


            builder.Property(x => x.Name)
               .IsRequired();

            builder.Property(x => x.BarCode)
               .IsRequired()
               .HasColumnType("varchar(14)");

            builder.Property(x => x.QuantityStock)
               .IsRequired();

            builder.Property(x => x.PriceSales)
               .IsRequired();

            builder.Property(x => x.PricePurchase)
               .IsRequired();            

            builder.ToTable("TB_Product");
        }
    }
}
