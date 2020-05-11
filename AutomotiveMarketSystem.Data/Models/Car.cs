using AutomotiveMarketSystem.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("Car")]
    public class Car : BaseEntity
    {
        public int Door { get; set; }

        public DateTime ProductionYear { get; set; }

        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Advertisement Advertisement { get; set; }

        public virtual ICollection<CarImage> CarImages { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("CarBrand")]
        public int CarBrandId { get; set; }
        public virtual CarBrand CarBrand { get; set; }

        public int CarModelId { get; set; }

        [ForeignKey("EngineTypeStatus")]
        public int EngineTypeId { get; set; }
        public virtual EngineTypeStatus EngineType { get; set; }
    }
}
