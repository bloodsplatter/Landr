using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Landr.Data;
using Landr.SDK;
using Landr.Web.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Landr.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddDataSource();
            services.ConfigureIdentity();

            //configure some extra cookie policies
            services.Configure<CookiePolicyOptions>(cookie =>
            {
                cookie.CheckConsentNeeded = context => true;
                cookie.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink(); //browser link enables extra debugging options from the browser, see: https://docs.microsoft.com/en-us/aspnet/core/client-side/using-browserlink?view=aspnetcore-2.1
                app.UseDatabaseErrorPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
