using AutomotiveMarketSystem.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("CarModel")]
    public class CarModel : BaseEntity
    {
        public string ModelName { get; set; }
        public CarBrand CarBrand { get; set; }
        public int CarBrandId { get; set; }
    }
}
