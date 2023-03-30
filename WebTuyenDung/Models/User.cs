using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Data.Configurations;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Models
{
    [EntityTypeConfiguration(typeof(UserEntityConfiguration))]
    public class User : BaseEntity
    {
        public string Username { get; set; } = default!;

        public string PasswordHashed { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string? Avatar { get; set; }

        public string? CoverImage { get; set; }

        public UserRole Role { get; set; }
    }
}
