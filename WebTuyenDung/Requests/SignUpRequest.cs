namespace WebTuyenDung.Requests
{
    public class SignUpRequest : SignInRequest
    {
        public string Name { get; set; } = default!;
    }
}
