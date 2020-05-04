﻿using AutoMapper;
using AutomotiveMarketSystem.Data;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly AutomotiveMarketSystemContext context;
        private readonly ICarService carService;
        private readonly IMapper mapper;

        public AdvertisementService(AutomotiveMarketSystemContext context, IMapper mapper, ICarService carService)
        {
            this.context = context;
            this.mapper = mapper;
            this.carService = carService;
        }

        private IQueryable<Advertisement> GetAds()
        {
            var allAds = this.context.Advertisements
                .Include(car => car.Car)
                .Include(user => user.User);

            return allAds;
        }

        public async Task<IEnumerable<AdvertisementViewModelDto>> ShowAllAdvertisement()
        {
            var allAds = this.GetAds();
            var resultAds = new List<AdvertisementViewModelDto>();

            foreach (var ad in allAds)
            {
                var currentUser = await this.context.Users.FirstOrDefaultAsync(userId => userId.Id == ad.UserId);
                var currentCar = await this.context.Cars.FirstOrDefaultAsync(carId => carId.Id == ad.CarId);
                resultAds.Add(new AdvertisementViewModelDto
                {
                    Id = ad.Id,
                    BrandName = await this.carService.GetBrandNameById(currentCar.CarBrandId),
                    ModelName = await this.carService.GetModelNameById(currentCar.CarModelId),
                    Door = currentCar.Door,
                    Price = currentCar.Price,
                    ProductionYear = currentCar.ProductionYear,
                    PublishDate = ad.PublishDate,
                    UserName = currentUser.UserName,
                    EngineTypeId = currentCar.EngineTypeStatusId
                });
            }


            return resultAds;

        }


        public async Task<AdvertisementDto> AddAdvertisement(AdvertisementDto dto)
        {
            var newAd = this.mapper.Map<Advertisement>(dto);
            var adExists = await this.context.Advertisements.ContainsAsync(newAd);
            if (adExists)
            {
                throw new ArgumentException($"There is already such ad in the db!");
            }

            //var currentUser = await this.context.Users
            //    .SingleOrDefaultAsync(userId => userId.Id == dto.UserId);

            var adId = await GetNextValue();
            newAd.Id = adId;
            newAd.UserId = dto.UserId;
            //  newAd.User = currentUser;
            newAd.PublishDate = DateTime.Now;

            await this.context.Advertisements.AddAsync(newAd);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<AdvertisementDto>(newAd);
        }

        private async Task<int> GetNextValue()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select Advertisement_Next_Id.NEXTVAL from dual";
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
