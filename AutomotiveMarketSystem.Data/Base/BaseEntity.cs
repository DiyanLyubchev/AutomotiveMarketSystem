using System;
using System.ComponentModel.DataAnnotations;

namespace AutomotiveMarketSystem.Data.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
