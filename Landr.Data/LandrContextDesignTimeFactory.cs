using Microsoft.EntityFrameworkCore.Design;

namespace Landr.Data
{
    // ReSharper disable once UnusedMember.Global
    public class LandrContextDesignTimeFactory : IDesignTimeDbContextFactory<LandrContext>
    {
        public LandrContext CreateDbContext(string[] args)
        {
            return new LandrContext(DataSourceConfigurator.CreateDbOptions(true));
        }
    }
}
