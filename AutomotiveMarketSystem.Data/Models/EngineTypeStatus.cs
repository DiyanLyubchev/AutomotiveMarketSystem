using AutomotiveMarketSystem.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("EngineTypeStatus")]
    public class EngineTypeStatus : BaseEntity
    {
        public string EngineType { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
