using WebTuyenDung.Validations;

namespace WebTuyenDung.Requests
{
    public class SignInRequest
    {
        public string Username { get; set; } = default!;

        [LengthBoundary(8, 63)]
        [PasswordComplexity]
        public string Password { get; set; } = default!;
    }
}
