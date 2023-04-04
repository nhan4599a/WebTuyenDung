using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTuyenDung.Models;

namespace WebTuyenDung.Data.Configurations
{
    public class PostEntityConfiguration : BaseEntityConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .IsRequired();
        }
    }
}
