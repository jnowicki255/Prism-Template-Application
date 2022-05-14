using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Repository.Tests.Infrastucture;
using PTA.TestBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static PTA.TestBase.Comparator;

namespace PTA.Repository.Tests.Tests
{
    [Collection(TestsCollections.DatabaseTests)]
    public class VehiclesTests : TestBase.TestBase, IDisposable
    {
        private readonly DatabaseTestFixture fixture;

        public VehiclesTests(DatabaseTestFixture fixture)
        {
            this.fixture = fixture;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        { }

        [Fact]
        public async Task CreateVehicle_AddItem_Success()
        {
            // Arrange
            var vehicleToAdd = new NewVehicle
            {
                Manufacturer = "Audi",
                Model = "RS6",
                Mileage = 120000,
                IsRented = false,
                LicencePlatesNumber = "DW 00055",
                Power = 650,
                VinNumber = "AAABBBCCCDDD",
                YearOfProduction = "2020",
                FuelTypeId = 1,
                VehicleTypeId = 1
            };

            // Act
            var result = await fixture.Repository.CreateVehicleAsync(vehicleToAdd);

            // Assert
            ShouldReturnSuccess(result);
            ShouldBeGreaterThanZero(result.Value.VehicleId);
            ComparePropertiesAndThrowIfMismatch(result.Value, vehicleToAdd);
        }
    }
}
