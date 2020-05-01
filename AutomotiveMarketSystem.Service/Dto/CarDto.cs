using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveMarketSystem.Service.Dto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public string CarModel { get; set; }

        public int Engine { get; set; }


        public int Door { get; set; }

        public DateTime ProductionYear { get; set; }

        public decimal Price { get; set; }

        public int EngineTypeStatusId { get; set; }

        public int AdvertisementId { get; set; }


        public int CarBrandId { get; set; }

 
        public int CarModelId { get; set; }
    }
}
