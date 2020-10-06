using Landr.Web.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Landr.Web.Extensions
{
    public static class LandrServiceExtensions
    {
        public static void AddLandr(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<UserSettingsRepository>();
        }
    }
}
