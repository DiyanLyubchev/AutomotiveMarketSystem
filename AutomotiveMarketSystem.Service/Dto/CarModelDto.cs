using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveMarketSystem.Service.Dto
{
    public class CarModelDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int CarBrandId { get; set; }
    }
}
