namespace WebTuyenDung.Configurations
{
    public class EmailConfiguration
    {
        public string FromEmailAddress { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string SmtpServerAddress { get; set; } = default!;

        public int SmtpServerPort { get; set; }
    }
}
