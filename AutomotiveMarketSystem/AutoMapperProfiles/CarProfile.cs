using AutoMapper;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Dto;

namespace AutomotiveMarketSystem.AutoMapperProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<CarDto, CarViewModel>().ReverseMap();
        }
    }
}
