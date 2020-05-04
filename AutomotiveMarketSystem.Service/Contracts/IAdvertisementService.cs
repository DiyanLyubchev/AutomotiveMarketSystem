using AutomotiveMarketSystem.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Service.Contracts
{
    public interface IAdvertisementService
    {
        Task<AdvertisementDto> AddAdvertisement(AdvertisementDto dto);
        Task<IEnumerable<AdvertisementViewModelDto>> ShowAllAdvertisement();
         Task<int> GetAdById(int id);

    }
}