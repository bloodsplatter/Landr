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
            AppSetup(modelBuilder);
            UserSettingsSetup(modelBuilder);
        }

        private void AppSetup(ModelBuilder modelBuilder)
        {
            var basicApp = modelBuilder.Entity<BaseApp>();
            basicApp.HasKey(ba => ba.Id);

            basicApp.Property(ba => ba.Name).IsRequired();
            basicApp.Property(ba => ba.Url).IsRequired();
        }

        private void UserSettingsSetup(ModelBuilder modelBuilder)
        {
            var userSettings = modelBuilder.Entity<UserSettings>();
            userSettings.HasKey(us => us.UserId);

            userSettings.ToTable("UserSettings");
        }

        public DbSet<BaseApp> Apps { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
    }
}
