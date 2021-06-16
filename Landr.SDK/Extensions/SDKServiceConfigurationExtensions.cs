using Microsoft.Extensions.DependencyInjection;

namespace Landr.SDK.Extensions
{
    public static class SDKServiceConfigurationExtensions
    {
        public static void ConfigureSDK(this IServiceCollection services)
        {
            services.AddScoped<IAppProvider, ExternalAppProvider>();
        }
    }
}
