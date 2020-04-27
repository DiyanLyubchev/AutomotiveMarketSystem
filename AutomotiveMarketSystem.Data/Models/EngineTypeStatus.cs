using AutomotiveMarketSystem.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("EngineTypeStatus")]
    public class EngineTypeStatus : BaseEntity
    {
        public string EngineType { get; set; }

        public virtual Car Car { get; set; }
    }
}
