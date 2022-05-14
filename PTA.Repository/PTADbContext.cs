using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PTA.Repository.Entities;
using PTA.Repository.Interfaces.Settings;
using PTA.Repository.Seeds;
using PTA.Repository.Settings;
using PTA.Settings;
using PTA.Types;

namespace PTA.Repository
{
    public class PTADbContext : DbContext
    {
        private readonly bool IsTestContext = false;

        public PTADbContext()
        { }

        public PTADbContext(ISqlDbSettings connSettings)
            : base(new DbContextOptionsBuilder<PTADbContext>().UseSqlServer(connSettings.ConnectionString).Options)
        {
            var conn = new SqlConnection(connSettings.ConnectionString);
            var dbName = conn.Database;
            conn.Dispose();

            if (dbName.Contains("TEST"))
                IsTestContext = true;
        }

        public PTADbContext(DbContextOptions<PTADbContext> options)
            : base(options)
        { }

        public virtual DbSet<DbUser> Users { get; set; }
        public virtual DbSet<DbVehicle> Vehicles { get; set; }
        public virtual DbSet<DbVehicleType> VehicleTypes { get; set; }
        public virtual DbSet<DbFuelType> FuelTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("globalSettings.json")
                    .Build();

                var dbSettings = configuration.GetSection(SettingsSections.Sql).Get<SqlDbSettings>();

                optionsBuilder.UseSqlServer(dbSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<DbUser>(entity =>
            {
                entity.Property(e => e.InsertDate).HasPrecision(3);
                entity.Property(e => e.ModifyDate).HasPrecision(3);
                entity.Property(e => e.LastLoginDate).HasPrecision(3);
                entity.Property(e => e.ExpirationDate).HasPrecision(3);
            });

            SeedDatabase(modelBuilder);

            if (!IsTestContext)
                SeedProductionDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.FuelTypeSeed();
            modelBuilder.VehicleTypeSeed();
        }

        private void SeedProductionDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.UsersSeed();
        }
    }
}
