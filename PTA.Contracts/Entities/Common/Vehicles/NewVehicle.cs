using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Contracts.Entities.Common.Vehicles
{
    public class NewVehicle
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string YearOfProduction { get; set; }
        public int Mileage { get; set; }
        public string VinNumber { get; set; }
        public string LicencePlatesNumber { get; set; }
        public bool IsRented { get; set; }
        public int Power { get; set; }
        public FuelType FuelType { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
