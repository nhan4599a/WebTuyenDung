namespace WebTuyenDung.Requests
{
    public class BaseSignUpRequest : SignInRequest
    {
        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;
    }
}
