using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebTuyenDung.Configurations;
using WebTuyenDung.Requests;

namespace WebTuyenDung.Services
{
    public class EmailService : IDisposable
    {
        private readonly SmtpClient _emailClient;
        private readonly string _fromMailAddress;

        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailClient = new SmtpClient
            {
                Credentials = new NetworkCredential
                {
                    UserName = emailConfiguration.FromEmailAddress,
                    Password = emailConfiguration.Password
                },
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = emailConfiguration.SmtpServerAddress,
                Port = emailConfiguration.SmtpServerPort
            };

            _fromMailAddress = emailConfiguration.FromEmailAddress;
        }

        public Task SendAsync(SendMailRequest request)
        {
            var mailMessage = new MailMessage(_fromMailAddress, request.ToAddress, request.Subject, request.Body)
            {
                IsBodyHtml = request.IsHTMLBody
            };
            return _emailClient.SendMailAsync(mailMessage);
        }

        public void Dispose()
        {
            _emailClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
