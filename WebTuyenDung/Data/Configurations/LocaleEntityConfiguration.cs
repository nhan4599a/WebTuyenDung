using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class LocaleEntityConfiguration : IEntityTypeConfiguration<Locale>
    {
        public void Configure(EntityTypeBuilder<Locale> builder)
        {
            builder
                .Ignore(e => e.IsDeleted)
                .Ignore(e => e.CreatedAt);

            builder
                .HasIndex(e => e.Parent);
        }
    }
}
