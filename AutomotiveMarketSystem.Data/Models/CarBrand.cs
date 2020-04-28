using AutomotiveMarketSystem.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("CarBrand")]
    public class CarBrand : BaseEntity
    {
        public string BrandName { get; set; }
        public IEnumerable<CarModel> BrandModels { get; set;}
        public IEnumerable<Car> Cars { get; set; }
       

    }
}
