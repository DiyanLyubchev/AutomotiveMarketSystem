using AutomotiveMarketSystem.Service.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required]
        [Range(2, 5)]
        public int Door { get; set; }


        [Required]
        public DateTime ProductionYear { get; set; } = DateTime.Now;


        [Required]
        [Range(1,10000000)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 4)]
        public int EngineTypeStatusId { get; set; }

        public int CarBrandId { get; set; }

        public int CarModelId { get; set; }

        public ICollection<CarBrandViewModel> AllCarModel { get; set; }

        public IEnumerable<CarModelViewModel> AllCarBrandByModel { get; set; }

        public int AdvertisementId { get; set; }

        public string BrandName { get; set; }
         
        public string ModelName { get; set; }
    }
}
