using System;
using WebTuyenDung.Enums;

namespace WebTuyenDung.ViewModels.Admin
{
    public class CandidateViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public Gender Gender { get; set; }

        public DateOnly BirthDay { get; set; }

        public string Address { get; set; } = default!;
    }
}
