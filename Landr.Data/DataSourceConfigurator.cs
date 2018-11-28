using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Landr.Data
{
    public static class DataSourceConfigurator
    {
        private const string ConnectionString = "Data Source=landr.db";

        /// <summary>
        /// To be called during ConfigureServices
        /// </summary>
        /// <param name="services">the service collection</param>
        public static void AddDataSource(this IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite().AddDbContext<LandrContext>(options => CreateDbOptions(false));
        }

        internal static DbContextOptions<LandrContext> CreateDbOptions(bool designTime = false)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LandrContext>();
            optionsBuilder.UseSqlite(ConnectionString);

            return optionsBuilder.Options;
        }
    }
}
