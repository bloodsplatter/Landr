using System.Net;

namespace Landr.Web.MessageService
{
    public class MessageServiceOptions
    {
        public const string ConfigSection = "MessageService";
        
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 465;
        public bool EnableSsl { get; set; } = true;
        public string From { get; set; } = string.Empty;
        public bool UseDevelopment { get; set; } = false;
    }
}
