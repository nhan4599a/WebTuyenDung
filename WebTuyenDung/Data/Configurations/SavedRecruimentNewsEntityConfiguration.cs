using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class SavedRecruimentNewsEntityConfiguration : IEntityTypeConfiguration<SavedRecruimentNews>
    {
        public void Configure(EntityTypeBuilder<SavedRecruimentNews> builder)
        {
            builder.HasIndex(e => new { e.CandidateId, e.RecruimentNewsId }).IsUnique();
        }
    }
}
