using Landr.SDK;
using Landr.Web.BuiltInApps;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SDKServiceConfigurationExtensions
    {
        public static void ConfigureSDK(this IServiceCollection services)
        {
            services.AddSingleton<IAppProvider, ExternalAppProvider>();
            services.AddSingleton<IAppProvider, BuiltInAppProvider>();
        }
    }
}
