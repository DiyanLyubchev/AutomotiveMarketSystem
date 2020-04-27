using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Models
{
    public class CarViewModel
    {
        public string Make { get; set; }

        public string CarModel { get; set; }

        public int Engine { get; set; }


        public int Door { get; set; }

        public DateTime ProductionYear { get; set; }

        public decimal Price { get; set; }

        public int EngineTypeStatusId { get; set; }

        public int AdvertisementId { get; set; }
    }
}
