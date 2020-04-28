using AutoMapper;
using AutomotiveMarketSystem.Data;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Service
{
    public class CarService : ICarService
    {
        private readonly AutomotiveMarketSystemContext context;
        private readonly IAdvertisementService advertisementService;
        private readonly IMapper mapper;

        public CarService(AutomotiveMarketSystemContext context, IMapper mapper, IAdvertisementService advertisementService)
        {
            this.context = context;
            this.mapper = mapper;
            this.advertisementService = advertisementService;
        }

        public async Task<CarDto> AddCar(CarDto car)
        {
            var newCar = this.mapper.Map<Car>(car);
            var carExists = await this.context.Cars.ContainsAsync(newCar);

            if (carExists)
            {
                throw new ArgumentException("There is already such car in the db!");
            }

            var carId = await GetNextValue();
            newCar.Id = carId;
           
            await this.context.Cars.AddAsync(newCar);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<CarDto>(newCar);
        }

        public async Task<int> GetNextValue()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select Car_Next_Id.NEXTVAL from dual";
                await context.Database.OpenConnectionAsync();

                using (var reader = command.ExecuteReader())
                {
                    await reader.ReadAsync();
                    return reader.GetInt32(0);
                }
            }
        }
    }
}
