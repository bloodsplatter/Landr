using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Landr.SDK;

namespace Landr.Data
{
    public class LandrContext : DbContext
    {
        public LandrContext(DbContextOptions<LandrContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BasicAppSetup(modelBuilder);
            AdvancedAppSetup(modelBuilder);
            
        }

        private EntityTypeBuilder<BasicApp> BasicAppSetup(ModelBuilder modelBuilder)
        {
            var basicApp = modelBuilder.Entity<BasicApp>();
            basicApp.HasKey(ba => ba.Id);

            basicApp.Property(ba => ba.Name).IsRequired();
            basicApp.Property(ba => ba.Url).IsRequired();

            return basicApp;
        }

        private EntityTypeBuilder<AdvancedApp> AdvancedAppSetup(ModelBuilder modelBuilder)
        {
            var advancedApp = modelBuilder.Entity<AdvancedApp>();
            advancedApp.ToTable("AdvancedApps");
            advancedApp.HasKey(aa => aa.Id);
            advancedApp.Property(aa => aa.Type).IsRequired();
            advancedApp.Property(aa => aa.Url).IsRequired();
            advancedApp.Property(aa => aa.Name).IsRequired();

            return advancedApp;
        }

        public DbSet<BasicApp> BasicApps { get; set; }
        public DbSet<AdvancedApp> AdvancedApps { get; set; }
    }
}
