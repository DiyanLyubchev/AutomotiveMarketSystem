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
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public CarService(AutomotiveMarketSystemContext context, IUserService userService, IMapper mapper)
        {
            this.context = context;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<CarDto> AddCar(CarDto car)
        {
            var brand = await this.context.CarBrands
                   .Include(cars => cars.Cars)
                   .SingleOrDefaultAsync(carBrand => carBrand.Id == car.CarModelId);

            var engine = await this.context.StatusEngines
           .Include(cars => cars.Cars)
           .SingleOrDefaultAsync(carBrand => carBrand.Id == car.EngineTypeId);

            var carId = await GetNextValue();

            var newCar = new Car
            {
                Id = carId,
                CarBrand = brand,
                CarBrandId = car.CarBrandId,
                CarModelId = car.CarModelId,
                Door = car.Door,
                EngineTypeId = car.EngineTypeId,
                EngineType = engine,
                Price = car.Price,
                ProductionYear = car.ProductionYear,
                UserId = car.UserId,
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

        private async Task<int> GetNextValue()
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

        public async Task<string> GetBrandNameById(int id)
        {
            var brand = await this.context.CarBrands.SingleOrDefaultAsync(brandId => brandId.Id == id);
            if (brand == null)
            {
                throw new ArgumentNullException("There is no such brand id!");
            }
            return brand.BrandName;
        }

        public async Task<string> GetModelNameById(int id)
        {
            var model = await this.context.CarModels.SingleOrDefaultAsync(modelId => modelId.Id == id);
            if (model == null)
            {
                throw new ArgumentNullException("There is no such brand id!");
            }
            return model.ModelName;
        }

        public async Task<CarDto> GetCarBy(int carId)
        {
            var currentCar = await this.context.Cars
                .SingleOrDefaultAsync(id => id.Id == carId && id.IsDeleted == false);

            return this.mapper.Map<CarDto>(currentCar);
        }

        public async Task<ICollection<CarDto>> ShowMyCars(string userId)
        {

            var listAds = await this.context.Advertisements.Where(x => x.UserId == userId).Select(x=>x.CarId).ToListAsync();

            var currentUserCars = await this.context.Cars
                .Include(x => x.User)
                .Include(x=>x.Advertisement)
                .Where(x => x.User.Id == userId && x.IsDeleted == false && !listAds
                .Contains(x.Id))
                .ToListAsync();

            var currentUserCarsDto = this.mapper.Map<List<CarDto>>(currentUserCars);
            return currentUserCarsDto;
        }


        public async Task UpdateCar(CarDto dto)
        {
            var currentCar = await this.context.Cars
                .SingleOrDefaultAsync(carId => carId.Id == dto.Id && carId.IsDeleted == false);

            currentCar.Price = dto.Price;
            currentCar.ProductionYear = dto.ProductionYear;
            currentCar.CarModelId = dto.CarModelId;
            currentCar.CarBrandId = dto.CarBrandId;
            currentCar.Door = dto.Door;
            currentCar.EngineTypeId = dto.EngineTypeId;

            await this.context.SaveChangesAsync();   
        }
    }
}

