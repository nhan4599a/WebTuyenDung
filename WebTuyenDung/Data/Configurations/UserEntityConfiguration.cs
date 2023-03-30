using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Enums;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class UserEntityConfiguration
        : IEntityTypeConfiguration<User>, IEntityTypeConfiguration<Candidate>, IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
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
