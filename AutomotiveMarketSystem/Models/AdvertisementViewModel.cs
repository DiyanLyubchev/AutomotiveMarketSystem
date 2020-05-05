using System;

namespace AutomotiveMarketSystem.Models
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public string ModelName { get; set; }

        public int Door { get; set; }

        public int EngineTypeId { get; set; }

        public DateTime ProductionYear { get; set; } = DateTime.Now;

        public decimal Price { get; set; }

        public string UserName { get; set; }

        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
