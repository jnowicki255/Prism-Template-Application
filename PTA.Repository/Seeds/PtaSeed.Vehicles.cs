using Microsoft.EntityFrameworkCore;
using PTA.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Repository.Seeds
{
    public static partial class PtaSeed
    {
        public static void FuelTypeSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbFuelType>().HasData(
                new DbFuelType { FuelTypeId = 1, FuelTypeName = "Petrol" },
                new DbFuelType { FuelTypeId = 2, FuelTypeName = "Diesel" },
                new DbFuelType { FuelTypeId = 3, FuelTypeName = "LPG" });
        }

        public static void VehicleTypeSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbVehicleType>().HasData(
                new DbVehicleType { VehicleTypeId = 1, VehicleTypeName = "Motorcycle" },
                new DbVehicleType { VehicleTypeId = 2, VehicleTypeName = "Pickup" },
                new DbVehicleType { VehicleTypeId = 3, VehicleTypeName = "SUV" }, 
                new DbVehicleType { VehicleTypeId = 4, VehicleTypeName = "Limousine" },
                new DbVehicleType { VehicleTypeId = 5, VehicleTypeName = "Cargo Van" });
        }
    }
}
