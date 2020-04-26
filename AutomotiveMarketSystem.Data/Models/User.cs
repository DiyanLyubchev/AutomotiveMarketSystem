using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotiveMarketSystem.Data.Models
{
    [Table("User")]
    public class User : IdentityUser
    {
        public virtual ICollection<Advertisement> Advertisements { get; set; } 
    }
}
