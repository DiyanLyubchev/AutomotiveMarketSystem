using AutomotiveMarketSystem.Service.Dto;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Service
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(string userId);
    }
}