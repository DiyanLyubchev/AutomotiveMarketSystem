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

        Task<CarDto> GetCarBy(int carId);

        Task<ICollection<CarDto>> ShowMyCars(string userId);

        Task<CarDto> UpdateCar(CarDto dto);
    }
}