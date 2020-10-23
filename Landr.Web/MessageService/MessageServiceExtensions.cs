using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

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
