namespace WebTuyenDung.Requests
{
    public class SendMailRequest
    {
        public string ToAddress { get; set; } = default!;

        public string Subject { get; set; } = default!;

        public string Body { get; set; } = default!;

        public bool IsHTMLBody { get; set; }
    }
}
