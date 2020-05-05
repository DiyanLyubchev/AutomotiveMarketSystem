using AutomotiveMarketSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveMarketSystem.Service.Dto
{
    public class CarDto
    {
        public int Id { get; set; }

        public int Door { get; set; }
        public IEnumerable<int> Doors { get; set; }

        public DateTime ProductionYear { get; set; } = DateTime.Now;

        public decimal Price { get; set; }

        public int EngineTypeId { get; set; }

        public int AdvertisementId { get; set; }


        public int CarBrandId { get; set; }


        public int CarModelId { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
    }
}
