using AutoMapper;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Dto;

namespace AutomotiveMarketSystem.AutoMapperProfiles
{
    public class CarModelProfile : Profile
    {
        public CarModelProfile()
        {
            CreateMap<CarModel, CarModelDto>().ReverseMap();
            CreateMap<CarModelViewModel, CarModelDto>().ReverseMap();
        }
    }
}
