namespace WebTuyenDung.ViewModels.Admin
{
    public class CandidateViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Gender { get; set; } = default!;

        public string BirthDay { get; set; } = default!;

        public string Address { get; set; } = default!;
    }
}
