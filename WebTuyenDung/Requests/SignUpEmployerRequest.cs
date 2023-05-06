namespace WebTuyenDung.Requests
{
    public class SignUpEmployerRequest : BaseSignUpRequest
    {
        public string Website { get; set; } = default!;

        public string Size { get; set; } = default!;

        public int CityId { get; set; }
    }
}
