using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class JobApplicationEntityConfiguration : BaseEntityConfiguration<JobApplication>
    {
        public override void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            base.Configure(builder);

            builder
                .HasIndex(e => e.RecruimentNewsId);

            builder
                .HasIndex(e => new { e.CandidateId, e.RecruimentNewsId, e.Status })
                .IsUnique();

            builder
                .HasOne<Candidate>()
                .WithMany()
                .HasForeignKey(e => e.CandidateId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder
                .HasOne<RecruimentNews>()
                .WithMany()
                .HasForeignKey(e => e.RecruimentNewsId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
