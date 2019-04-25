using System.Threading.Tasks;

namespace Landr.Web.MessageService
{
    public interface IMessageService
    {
        Task Send(string emailAddress, string verificationUrl);
    }
}