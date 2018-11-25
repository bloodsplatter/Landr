using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Landr.Data
{
    public class LandrContext : DbContext
    {
        public LandrContext(DbContextOptions<LandrContext> options) : base(options)
        {}

        //TODO: Create models, add as DbSet<T> properties
    }
}
