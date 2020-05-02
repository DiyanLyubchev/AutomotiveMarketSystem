using AutomotiveMarketSystem.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("CarBrand")]
    public class CarBrand : BaseEntity
    {
        public string BrandName { get; set; }

        public virtual ICollection<CarModel> BrandModels { get; set;}

        public virtual ICollection<Car> Cars { get; set; }
    }
}
