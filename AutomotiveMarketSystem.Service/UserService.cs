using AutoMapper;
using AutomotiveMarketSystem.Data;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Service
{
    public class UserService : IUserService
    {
        private readonly AutomotiveMarketSystemContext context;
        private readonly IMapper mapper;

        public UserService(AutomotiveMarketSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserDTO> GetUserById(string userId)
        {
            var curentUser = await this.context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            var currentUserDto = this.mapper.Map<UserDTO>(curentUser);
            return currentUserDto;
        }
    }
}
