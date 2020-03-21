using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServiceConfigurationExtensions
    {
        private const string AllowedUsernameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        private const string UsersDbFileName = "users.db";

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                //Password settings
                options.Password.RequireLowercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                
                //Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                //User settings
                options.User.AllowedUserNameCharacters = AllowedUsernameCharacters;
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);

                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/User/AccessDenied";
                options.SlidingExpiration = true;
            });

            //change this method (and the packages) to change the Identity store (i.e. to SQL Server)
            DbContextOptionsBuilder CreateIdentityDbOptions(DbContextOptionsBuilder optionsBuilder)
            {
                return optionsBuilder.UseSqlite($"Data Source={UsersDbFileName}", options => options.MigrationsAssembly("Landr.Web"));
            }

            services.AddDbContext<IdentityDbContext>(options => CreateIdentityDbOptions(options));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
