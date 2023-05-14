using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class NotificationEntityConfiguration : BaseEntityConfiguration<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);

            builder.HasIndex(e => e.CandidateId);
        }
    }
}
