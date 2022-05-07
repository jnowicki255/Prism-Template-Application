using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Repository.Entities
{
    public partial class DbFuelType
    {
        [Key]
        public int FuelTypeId { get; set; }

        [Required, StringLength(50)]
        public string FuelTypeName { get; set; }

        [InverseProperty(nameof(DbVehicle.FuelType))]
        public virtual ICollection<DbVehicle> Vehicles { get; set; }
    }
}