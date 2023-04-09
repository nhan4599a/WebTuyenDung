using System.Collections.Generic;

namespace WebTuyenDung.Models
{
    public class Employer : User
    {
        public string Address { get; set; } = default!;

        public int CityId { get; set; }

        public string Size { get; set; } = default!;

        public string Website { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public Locale City { get; set; } = default!;

        public ICollection<RecruimentNews> RecruimentNews { get; set; } = default!;
    }
}
