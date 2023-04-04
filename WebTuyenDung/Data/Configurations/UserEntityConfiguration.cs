using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class UserEntityConfiguration
        : BaseEntityConfiguration<User>, IEntityTypeConfiguration<Candidate>, IEntityTypeConfiguration<Employer>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder
                .HasIndex(e => e.Role);

            builder
                .HasIndex(e => e.Username)
                .IsUnique();
        }

        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
        }

        public void Configure(EntityTypeBuilder<Employer> builder)
        {
        }
    }
}
