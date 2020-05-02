using AutomotiveMarketSystem.Data.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("Car")]
    public class Car : BaseEntity
    {
        public int Door { get; set; }

        public DateTime ProductionYear { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("CarBrand")]
        public int CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }

        [ForeignKey("EngineTypeStatus")]
        public int EngineTypeStatusId { get; set; }
        
        public virtual EngineTypeStatus EngineType { get; set; }
      
        
        public virtual Advertisement Advertisement { get; set; }

    }
}
