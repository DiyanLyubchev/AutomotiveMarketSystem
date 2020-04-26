using AutomotiveMarketSystem.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("EngineTypeStatus")]
    public class EngineTypeStatus : BaseEntity
    {
        public string EngineType { get; set; }

        public virtual Car Car { get; set; }
    }
}
