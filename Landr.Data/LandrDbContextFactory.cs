using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Landr.Data
{
    public class LandrDbContextFactory : IDesignTimeDbContextFactory<LandrContext>
    {
        public LandrContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LandrContext>();
            optionsBuilder.UseSqlite("Filename=Landr.db"); //TODO: this must come from config file

            return new LandrContext(optionsBuilder.Options);
        }
    }
}
