using AutomotiveMarketSystem.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Service.Contracts
{
    public interface ICarService
    {
        Task<CarDto> AddCar(CarDto car);

        Task<IEnumerable<CarModelDto>> GetModelByBrandIdAsync(int carBrandId);

        Task<IEnumerable<CarBrandDto>> GetAllModelAsync();
        Task<string> GetBrandNameById(int id);
        Task<string> GetModelNameById(int id);
    }
}