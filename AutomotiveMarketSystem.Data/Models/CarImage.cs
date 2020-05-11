using AutomotiveMarketSystem.Data.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("CarImage")]
    public class CarImage : BaseEntity
    {
        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
