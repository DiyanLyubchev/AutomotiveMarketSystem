using AutoMapper;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Service.Dto;

namespace AutomotiveMarketSystem.AutoMapperProfiles
{
    public class CarImageProfile : Profile
    {
        public CarImageProfile()
        {
            CreateMap<CarImage, CarImageDto>().ReverseMap();
        }
    }
}
