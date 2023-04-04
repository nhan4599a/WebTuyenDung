using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class CurriculumVitaeEntityConfiguration : BaseEntityConfiguration<CurriculumVitae>
    {
        public override void Configure(EntityTypeBuilder<CurriculumVitae> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasIndex(e => e.CandidateId);

            builder
                .HasIndex(e => new { e.CandidateId, e.Name })
                .IsUnique();
        }
    }
}
