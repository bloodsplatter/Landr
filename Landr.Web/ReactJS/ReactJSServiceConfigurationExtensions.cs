using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Microsoft.AspNetCore.Builder;
using System.IO;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ReactJSServiceConfigurationExtensions
    {
        private const string ReactScriptRoot = @"wwwroot\react";

        public static void ConfigureReactJS(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddReact();

            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();
        }

        public static void UseReact(this IApplicationBuilder app)
        {
            app.UseReact(config =>
            {
                config.AllowJavaScriptPrecompilation = true;
                //config.UseServerSideRendering = true;

                var reactScriptRoot = Path.Combine(Environment.CurrentDirectory, ReactScriptRoot);

                var reactFiles = FindReactFiles(reactScriptRoot);

                foreach (var file in reactFiles)
                {
                    config.AddScript(file);
                }
            });
        }

        private static string[] FindReactFiles(string root)
        {
            return Directory.GetFiles(root, "*.jsx", SearchOption.AllDirectories);
        }
    }
}
