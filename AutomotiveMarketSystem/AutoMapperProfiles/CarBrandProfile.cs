using AutoMapper;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.AutoMapperProfiles
{
    public class CarBrandProfile : Profile
    {
        public CarBrandProfile()
        {
            CreateMap<CarBrand, CarBrandDto>().ReverseMap();
            CreateMap<CarBrandViewModel, CarBrandDto>().ReverseMap();
        }
    }
}
