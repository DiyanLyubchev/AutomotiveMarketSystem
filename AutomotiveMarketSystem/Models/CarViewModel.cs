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
        public string Brand { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        public int Engine { get; set; }

        [Required]
        [Range(3,5)]
        public int Door { get; set; }

        public DateTime ProductionYear { get; set; }

        public decimal Price { get; set; }

        public int EngineTypeStatusId { get; set; }
     
        public int CarBrandId { get; set; }


        public int CarModelId { get; set; }

        public ICollection<CarBrandViewModel> AllCarModel { get; set; }

        public IEnumerable<CarModelViewModel> AllCarBrandByModel { get; set; }

        public int AdvertisementId { get; set; }
    }
}
