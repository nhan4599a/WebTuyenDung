using System;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Models
{
    public class Candidate : User
    {
        public DateOnly BirthDay { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public int ApprovedCount { get; set; }
    }
}
