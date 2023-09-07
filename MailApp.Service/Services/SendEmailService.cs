using Microsoft.Extensions.Options;
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MailApp.API.Service;
using MailApp.Core.Helpter;
using MailApp.API.Helpter;

namespace EmailService.API.Service
{
    public class SendEmailService : ISendEmailService
    {
        private readonly EmailSettings emailSettings;
        public SendEmailService(IOptions<EmailSettings> options) { 
            this.emailSettings=options.Value;
        }
        public async Task SendEmailAsync(MailRequest mailrequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailrequest.ToEmail));
            email.Subject=mailrequest.Subject;
            var builder = new BodyBuilder();
          
            builder.HtmlBody = mailrequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
