using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Repository.Entities
{
    public partial class DbVehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }
        
        [Required, StringLength(50)]
        public string VehicleTypeName { get; set; }

        [InverseProperty(nameof(DbVehicle.VehicleType))]
        public virtual ICollection<DbVehicle> Vehicles { get; set; }
    }
}
