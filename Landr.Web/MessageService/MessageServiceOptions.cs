using System.Net;

namespace Landr.Web.MessageService
{
    public class MessageServiceOptions
    {
        public const string TopLevel = "Smtp";
        public const string ServerAddress = "Smtp:Server";
        public const string ServerPort = "Smtp:Port";
        public const string ServerUseSSL = "Smtp:UseSSL";
        public const string ServerFrom = "Smtp:From";

        public ICredentialsByHost SmtpCredentials { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string From { get; set; }
    }
}
