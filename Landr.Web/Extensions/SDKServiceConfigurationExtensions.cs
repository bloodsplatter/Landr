using Landr.SDK;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SDKServiceConfigurationExtensions
    {
        public static void ConfigureSDK(this IServiceCollection services)
        {
            services.AddSingleton<IAppProvider, StandardAppProvider>();
        }
    }
}
