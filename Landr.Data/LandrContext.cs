using System;
using Microsoft.EntityFrameworkCore;
using Landr.SDK;

namespace Landr.Data
{
    public class LandrContext : DbContext
    {
        public LandrContext(DbContextOptions<LandrContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BasicApp
            var basicApp = modelBuilder.Entity<BasicApp>();
            basicApp.HasKey(ba => ba.Id);
            basicApp.Property(ba => ba.Name).IsRequired();
            basicApp.Property(ba => ba.Url).IsRequired();

            //AdvancedApp
            var advancedApp = modelBuilder.Entity<AdvancedAppContract>();
            advancedApp.ToTable("AdvancedApps");
            advancedApp.HasKey(aa => aa.Id);
            advancedApp.Property(aa => aa.Type).IsRequired();
            advancedApp.Property(aa => aa.Url).IsRequired();
            advancedApp.Property(aa => aa.Name).IsRequired();
        }

        //TODO: Create models, add as DbSet<T> properties

        public DbSet<BasicApp> BasicApps { get; set; }
        public DbSet<AdvancedAppContract> AdvancedApps { get; set; }
    }
}
