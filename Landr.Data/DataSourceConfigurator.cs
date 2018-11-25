using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Landr.Data
{
    public static class DataSourceConfigurator
    {
        /// <summary>
        /// To be called during ConfigureServices
        /// </summary>
        /// <param name="services">the service collection</param>
        public static void AddDataSource(this IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite().AddDbContext<LandrContext>();
        }
    }
}
