using System;
using System.Collections.Generic;

namespace WebTuyenDung.Models
{
    public class Employer : User
    {
        public string Address { get; set; } = default!;

        public int CityId { get; set; }

        public string? Size { get; set; }

        public string? Website { get; set; }

        public string? Description { get; set; }

        public string PhoneNumber { get; set; } = default!;

        public Locale City { get; set; } = default!;

        public DateTimeOffset? LockedOutAt { get; set; }

        public bool IsApproved { get; set; }

        public ICollection<RecruimentNews> RecruimentNews { get; set; } = default!;
    }
}
