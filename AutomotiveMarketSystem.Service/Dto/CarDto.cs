using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AutomotiveMarketSystem.Service.Dto
{
    public class CarDto
    {
        public int Id { get; set; }

        public int Door { get; set; }
        
        public DateTime ProductionYear { get; set; } = DateTime.Now;

        public decimal Price { get; set; }

        public int EngineTypeId { get; set; }

        public int AdvertisementId { get; set; }


        public int CarBrandId { get; set; }


        public int CarModelId { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<CarImageDto> CarImages { get; set; }

        public IFormFile Image { get; set; }
        public List<IFormFile> Images { get; set; }
        public string ImagePath { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}
