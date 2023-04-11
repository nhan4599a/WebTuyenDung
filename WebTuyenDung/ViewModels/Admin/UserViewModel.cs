using System;

namespace WebTuyenDung.ViewModels.Admin
{
    public class UserViewModel
    {
        public string Username { get; set; } = default!;

        public string Role { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; }
    }
}
