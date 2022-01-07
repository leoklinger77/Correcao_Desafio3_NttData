using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Infra.Mappings
{
    public class EmailMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EmailAddress)
               .IsRequired();

            builder.ToTable("TB_Email");
        }
    }
}
