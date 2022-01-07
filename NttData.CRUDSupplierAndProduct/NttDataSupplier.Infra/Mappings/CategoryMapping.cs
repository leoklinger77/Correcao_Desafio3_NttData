using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Products)
               .WithOne(x => x.Category)
               .HasForeignKey(x => x.CategoryId);

            builder.Property(x => x.Name)
               .IsRequired();

            builder.ToTable("TB_Category");
        }
    }
}
