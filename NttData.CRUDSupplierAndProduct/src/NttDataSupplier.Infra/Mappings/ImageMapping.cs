using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class ImageMapping : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImagePath)
              .IsRequired();

            builder.ToTable("TB_Image");
        }
    }
}
