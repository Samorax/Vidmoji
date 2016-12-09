using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using SendGrid;
using System.Configuration;
using SendGrid.Helpers.Mail;

namespace WebApplication1.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return configureSendGridAsync(message);
        }

        private async static Task configureSendGridAsync(IdentityMessage message)
        {
            var apiKey = ConfigurationManager.AppSettings["SendGridKey"];
            var SClient = new SendGridAPIClient(apiKey);
            var from = new Email(ConfigurationManager.AppSettings["AppEmailAddress"]);
            var to = new Email(message.Destination);
            var subject = message.Subject;
            var content = new Content("text/plain",message.Body);
            var Mail = new Mail(from, subject, to, content);

            var response = await SClient.client.Mail.send.post(Mail.Get());
        }
    }
}