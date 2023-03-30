namespace WebTuyenDung.Models
{
    public class Employer : User
    {
        public string Address { get; set; } = default!;

        public string Site { get; set; } = default!;

        public string Size { get; set; } = default!;

        public string Website { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;
    }
}
