using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(PostEntityConfiguration))]
    public class Post : BasePostEntity
    {
        public string Title { get; set; } = default!;

        public string Image { get; set; } = default!;

        public string Content { get; set; } = default!;

        public int CreatedBy { get; set; }

        public User Author { get; set; } = default!;
    }
}
