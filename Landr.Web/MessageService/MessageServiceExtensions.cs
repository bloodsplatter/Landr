using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Landr.Web.MessageService
{
    public static class MessageServiceExtensions
    {
        public static void AddMessageService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MessageServiceOptions>(o => config.GetSection(MessageServiceOptions.ConfigSection).Bind(o));
            services.AddScoped<IViewRender, ViewRender>();

            var options =
                config.Get<MessageServiceOptions>(o => config.GetSection(MessageServiceOptions.ConfigSection).Bind(o));

            if (options.UseDevelopment)
            {
                services.AddScoped<IMessageService, NullMessageService>();
            }
            else
            {
                services.AddScoped<IMessageService, SmtpMessageService>();
            }
        }
    }
}
