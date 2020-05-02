using AutomotiveMarketSystem.Data.Base;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("Advertisements")]
    public class Advertisement : BaseEntity
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
