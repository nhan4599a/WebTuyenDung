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
                .HasQueryFilter(e => !e.IsDeleted && !e.Employer.IsDeleted);

            builder
                .HasIndex(e => e.CityId);
        }
    }
}
