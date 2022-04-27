using AutoMapper;
using Microsoft.Extensions.Configuration;
using PTA.Repository.Interfaces.Settings;
using PTA.Repository.Settings;
using System;

namespace PTA.Repository.Tests.Infrastucture
{
    public class DatabaseTestFixture : IDisposable
    {
        private readonly string connectionString;
        private readonly IMapper mapper;
        private readonly ISqlDbSettings sqlDbSettings;

        public Repos.Repository Repository => PrepareRepository();
        public PTADbContext DbContext => new(sqlDbSettings);


        public DatabaseTestFixture()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("repositoryTestSettings.json")
                .Build();

            connectionString = configuration.GetSection("SqlDb")
                                            .Get<SqlDbSettings>()?
                                            .ConnectionString;

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DbMappingProfile());
            });

            this.mapper = mapperConfig.CreateMapper();

            this.sqlDbSettings = new SqlDbSettings()
            {
                ConnectionString = this.connectionString
            };

            SeedTestDatabase();
        }

        private void SeedTestDatabase()
        {
            this.DbContext.Database.EnsureDeleted();
            this.DbContext.Database.EnsureCreated();

            var testDataSeed = new TestDataSeed(DbContext);
            testDataSeed.InsertData();
        }

        private Repos.Repository PrepareRepository()
        {
            return new Repos.Repository(new PTADbContext(this.sqlDbSettings), this.mapper, this.sqlDbSettings);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.DbContext.Database.EnsureDeleted();
        }
    }
}
