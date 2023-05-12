using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class LikedCurriculumVitaeEntityConfiguration : BaseEntityConfiguration<LikedCurriculumVitae>
    {
        public override void Configure(EntityTypeBuilder<LikedCurriculumVitae> builder)
        {
            base.Configure(builder);

            builder.HasIndex(e => e.EmployerId);
        }
    }
}
