using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Landr.Web.MessageService
{
    public class NullMessageService : IMessageService
    {
        private readonly ILogger<NullMessageService> _logger;

        public NullMessageService(ILogger<NullMessageService> logger)
        {
            _logger = logger;
        }
        
        public Task Send(string emailAddress, string verificationUrl)
        {
            _logger.LogInformation("Verification for email {Email} with url {Url}", emailAddress, verificationUrl);

            return Task.CompletedTask;
        }
    }
}