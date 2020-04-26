using AutomotiveMarketSystem.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("Advertisement")]
    public class Advertisement : BaseEntity
    {
        public string UserId { get; set; }

        public virtual User Users { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
