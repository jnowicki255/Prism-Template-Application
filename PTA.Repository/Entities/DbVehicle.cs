using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Repository.Entities
{
    public partial class DbVehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Precision(3)]
        public DateTime InsertDate { get; set; }

        [Precision(3)]
        public DateTime ModifyDate { get; set; }

        [Required, StringLength(100)]
        public string Manufacturer { get; set; }

        [Required, StringLength(100)]
        public string Model { get; set; }

        public int YearOfProduction { get; set; }

        public int Mileage { get; set; }

        public bool IsRented { get; set; }

        public int VehicleTypeId { get; set; }

        public int FuelTypeId { get; set; }

        public int Power { get; set; }

        [Required, StringLength(17)]
        public string VinNumber { get; set; }

        [Required, StringLength(15)]
        public string LicencePlatesNumber { get; set; }

        [ForeignKey(nameof(FuelTypeId)), InverseProperty(nameof(DbFuelType.Vehicles))]
        public virtual DbFuelType FuelType { get; set; }

        [ForeignKey(nameof(VehicleTypeId)), InverseProperty(nameof(DbVehicleType.Vehicles))]
        public virtual DbVehicleType VehicleType { get; set; }
    }
}
