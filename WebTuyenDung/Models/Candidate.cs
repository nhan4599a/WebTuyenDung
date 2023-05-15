using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebTuyenDung.Enums;

namespace WebTuyenDung.Models
{
    public class Candidate : User
    {
        public DateOnly BirthDay { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; } = default!;

        [MaxLength(10)]
        public string PhoneNumber { get; set; } = default!;
    }
}
