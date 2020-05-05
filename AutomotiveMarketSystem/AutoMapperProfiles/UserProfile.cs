using AutoMapper;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Dto;

namespace AutomotiveMarketSystem.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
        }
    }
}
