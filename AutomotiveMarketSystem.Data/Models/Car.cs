using AutomotiveMarketSystem.Data.Base;
using AutomotiveMarketSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("Car")]
    public class Car : BaseEntity
    {
        public CarBrand CarBrand { get; set; }
        public int CarBrandId { get; set; }

        //public string CarModel { get; set; }

        public int Engine { get; set; }


        public int Door { get; set; }

        public DateTime ProductionYear { get; set; }

        public decimal Price { get; set; }

        public int EngineTypeStatusId { get; set; }

        public virtual EngineTypeStatus EngineType { get; set; }

        public int AdvertisementId { get; set; }

        public virtual Advertisement Advertisement { get; set; }
    }
}
