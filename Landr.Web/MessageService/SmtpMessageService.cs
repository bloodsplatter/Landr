using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;

namespace Landr.Web.MessageService
{
    public class SmtpMessageService : IMessageService
    {
        #region Configuration Keys

        private const string ServerAddress = "Smtp:Server";
        private const string ServerPort = "Smtp:Port";
        private const string ServerUseSSL = "Smtp:UseSSL";
        private const string ServerFrom = "Smtp:From";

        #endregion
        
        private readonly SmtpClient _client;
        private readonly IStringLocalizer<SmtpMessageService> _l;
        private readonly string _from;
        private readonly ViewRender _viewRenderer;

        public SmtpMessageService(IStringLocalizer<SmtpMessageService> localizer, ICredentialsByHost credentials, IConfiguration config, ViewRender viewRenderer)
        {
            _l = localizer;
            _client = new SmtpClient
            {
                Credentials = credentials,
                Host = config[ServerAddress],
                Port = int.Parse(config[ServerPort]),
                EnableSsl = bool.Parse(config[ServerUseSSL])
            };

            _from = config[ServerFrom];
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