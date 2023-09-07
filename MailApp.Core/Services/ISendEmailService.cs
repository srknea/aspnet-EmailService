using MailApp.Core.Helpter;

namespace MailApp.API.Service
{
    public interface ISendEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
