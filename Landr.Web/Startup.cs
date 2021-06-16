﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Landr.Data;
using Landr.SDK.Extensions;
using Landr.Web.MessageService;
using Microsoft.AspNetCore.Mvc;
using Landr.Web.Extensions;

namespace Landr.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization();

            services.AddRazorPages();

            services.AddDataSource();
            services.ConfigureIdentity();

            services.ConfigureSDK(); // initialize Landr SDK

            services.AddMessageService(Configuration);

            services.AddLandr();

            //configure some extra cookie policies
            services.Configure<CookiePolicyOptions>(cookie =>
            {
                cookie.CheckConsentNeeded = context => true;
                cookie.MinimumSameSitePolicy = SameSiteMode.None;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink(); //browser link enables extra debugging options from the browser, see: https://docs.microsoft.com/en-us/aspnet/core/client-side/using-browserlink?view=aspnetcore-2.
            }

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers.Append(
                            "Cache-Control", "no-store");
                    }
                });
            } else
            {
                app.UseStaticFiles();
            }

            app.UseRouting();
            app.UseEndpoints(builder =>
            {
                builder.MapControllers();
                builder.MapDefaultControllerRoute();
            });
        }
    }
}
