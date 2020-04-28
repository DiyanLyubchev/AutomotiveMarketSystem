using AutomotiveMarketSystem.Service.Dto;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Service.Contracts
{
    public interface ICarService
    {
        Task<CarDto> AddCar(CarDto car);
    }
}