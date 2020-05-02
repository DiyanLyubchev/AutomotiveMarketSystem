using AutoMapper;
using AutomotiveMarketSystem.Data;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            //var newCar = this.mapper.Map<Car>(car);

            var brand = await this.context.CarBrands
                .Include(cars => cars.Cars)
                .SingleOrDefaultAsync(carBrand => carBrand.Id == car.CarModelId);

            var engine = await this.context.StatusEngines
           .Include(cars => cars.Car)
           .SingleOrDefaultAsync(carBrand => carBrand.Id == car.EngineTypeStatusId);

            var carId = await GetNextValue();
            //newCar.Id = carId;
            //newCar.CarBrand = brand;

            var newCar = new Car
            {
                Id = carId,
                CarBrand = brand,
                CarBrandId = car.CarBrandId,
                Door = car.Door,
                EngineTypeStatusId = car.EngineTypeStatusId,
                EngineType = engine,
                Price = car.Price,
                ProductionYear = car.ProductionYear
            };

            await this.context.Cars.AddAsync(newCar);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<CarDto>(newCar);
        }
        public async Task<IEnumerable<CarModelDto>> GetModelByBrandIdAsync(int carBrandId)
        {
            var allModels = await this.context.CarModels
                  .Include(brand => brand.CarBrand)
                  .Where(model => model.CarBrandId == carBrandId)
                  .Select(model => new CarModelDto
                  {
                      Id = model.Id,
                      ModelName = model.ModelName,
                      CarBrandId = model.CarBrandId,
                  }).ToListAsync();

            return allModels;
        }

        public async Task<IEnumerable<CarBrandDto>> GetAllModelAsync()
        {
            return await this.context.CarBrands.Select(model => new CarBrandDto
            {
                Id = model.Id,
                BrandName = model.BrandName
            }).ToListAsync();
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

