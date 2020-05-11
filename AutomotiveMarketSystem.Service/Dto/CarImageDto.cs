using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveMarketSystem.Service.Dto
{
    public class CarImageDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int CarId { get; set; }
    }
}
