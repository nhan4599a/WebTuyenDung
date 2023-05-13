using System;
using WebTuyenDung.Enums;

namespace WebTuyenDung.ViewModels.Admin
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; } = default!;

        public UserRole Role { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; }
    }
}
