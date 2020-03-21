using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ReactJSServiceConfigurationExtensions
    {
        public static void ConfigureReactJS(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddReact();

            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();
        }
    }
}
