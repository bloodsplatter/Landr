using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Landr.Web.MessageService
{
    public class SmtpMessageService : IMessageService
    {        
        private readonly SmtpClient _client;
        private readonly IStringLocalizer<SmtpMessageService> _l;
        private readonly string _from;
        private readonly IViewRender _viewRenderer;

        public SmtpMessageService(IStringLocalizer<SmtpMessageService> localizer, IOptions<MessageServiceOptions> options, IViewRender viewRenderer)
        {
            _l = localizer;
            
            _client = new SmtpClient
            {
                Credentials = options.Value.SmtpCredentials,
                Host = options.Value.Host,
                Port = options.Value.Port,
                EnableSsl = options.Value.EnableSsl
            };

            _from = options.Value.From;
            _viewRenderer = viewRenderer;
        }


        public Task Send(string to, string verificationUrl)
        {
            return _client.SendMailAsync(BuildMailMessage(to, verificationUrl));
        }

        private MailMessage BuildMailMessage(string to, string verificationUrl)
        {
            var message = new MailMessage(_from, to) {
                Body = RenderMailTemplate(verificationUrl),
                BodyEncoding = Encoding.UTF8
            };

            return message;
        }

        private string RenderMailTemplate(string verificationUrl)
        {
            var model = new {
                Name = "Tester",
                VerificationLink = verificationUrl
            };

            return _viewRenderer.Render("MailTemplates/RegistrationVerificationMail", model);
        }
    }
}