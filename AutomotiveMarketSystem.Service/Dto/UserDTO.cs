using AutomotiveMarketSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveMarketSystem.Service.Dto
{
    public class UserDTO
    {
        public string Id { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
