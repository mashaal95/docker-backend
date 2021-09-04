using System;
using System.Reflection;
using Backend_KubesProject_DotNet;
using Microsoft.EntityFrameworkCore;


namespace Backend_KubesProject_DotNet
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var config = AppConfig.Build();
                optionsBuilder.UseNpgsql(config.DatabaseConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DatabaseContext)));

            modelBuilder.Entity<WeatherForecast>().HasKey(e => e.Id);
        }
    }
}