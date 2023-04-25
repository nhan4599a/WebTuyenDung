using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class CurriculumVitaeDetailEntityConfiguration : BaseEntityConfiguration<CurriculumVitaeDetail>
    {
        public override void Configure(EntityTypeBuilder<CurriculumVitaeDetail> builder)
        {
            base.Configure(builder);
        }
    }
}
