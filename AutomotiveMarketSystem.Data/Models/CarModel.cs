using AutomotiveMarketSystem.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("CarModel")]
    public class CarModel : BaseEntity
    {
        public string ModelName { get; set; }

        [ForeignKey("CarBrand")]
        public int CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }
    }
}
