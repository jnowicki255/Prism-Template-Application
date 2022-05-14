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
        public int FuelTypeId { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
