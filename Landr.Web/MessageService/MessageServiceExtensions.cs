using Microsoft.Extensions.DependencyInjection;

namespace Landr.Web.MessageService
{
    public static class MessageServiceExtensions
    {
        public static void AddMessageService(this IServiceCollection services)
        {
            services.AddScoped<IViewRender, ViewRender>();
            services.AddScoped<IMessageService, SmtpMessageService>();
        }
    }
}
