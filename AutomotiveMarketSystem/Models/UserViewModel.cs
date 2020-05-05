using AutomotiveMarketSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Models
{
    public class UserViewModel
    {        
        public string Id { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
