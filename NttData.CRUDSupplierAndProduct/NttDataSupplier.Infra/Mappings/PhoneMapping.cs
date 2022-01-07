using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class PhoneMapping : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ddd)
                .IsRequired()
            .HasColumnType("char(2)");

            builder.Property(x => x.Number)
                .IsRequired()
            .HasColumnType("varchar(9)");

            builder.ToTable("TB_Phone");
        }
    }
}
