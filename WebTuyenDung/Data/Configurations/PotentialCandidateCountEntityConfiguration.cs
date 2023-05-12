using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class PotentialCandidateCountEntityConfiguration : BaseEntityConfiguration<PotentialCandidateCount>
    {
        public override void Configure(EntityTypeBuilder<PotentialCandidateCount> builder)
        {
            base.Configure(builder);

            builder.HasIndex(e => new { e.CandidateId, e.JobPosition }).IsUnique();

            builder
                .HasOne(e => e.Candidate)
                .WithMany()
                .HasForeignKey(e => e.CandidateId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
