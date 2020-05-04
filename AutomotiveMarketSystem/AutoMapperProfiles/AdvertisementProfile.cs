using AutoMapper;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Dto;

namespace AutomotiveMarketSystem.AutoMapperProfiles
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<Advertisement, AdvertisementDto>().ReverseMap();
           // CreateMap<AdvertisementViewModel, AdvertisementDto>().ReverseMap();
            CreateMap<AdvertisementViewModel, AdvertisementViewModelDto>().ReverseMap();
        }
    }
}
