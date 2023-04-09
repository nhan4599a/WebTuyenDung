using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class RecruimentNewsEntityConfiguration : BaseEntityConfiguration<RecruimentNews>
    {
        public override void Configure(EntityTypeBuilder<RecruimentNews> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(e => e.Employer)
                .WithMany(e => e.RecruimentNews)
                .HasForeignKey(e => e.EmployerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasQueryFilter(e => !e.IsDeleted && !e.Employer.IsDeleted);

            builder
                .HasIndex(e => e.CityId);
        }
    }
}
