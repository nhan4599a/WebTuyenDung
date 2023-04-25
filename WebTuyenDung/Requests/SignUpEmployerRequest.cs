namespace WebTuyenDung.Requests
{
    public class SignUpEmployerRequest : SignUpRequest
    {
        public string Website { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Size { get; set; } = default!;

        public int CityId { get; set; }
    }
}
