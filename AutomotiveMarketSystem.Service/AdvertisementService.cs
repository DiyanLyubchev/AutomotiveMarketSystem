using AutoMapper;
using AutomotiveMarketSystem.Data;
using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly AutomotiveMarketSystemContext context;
        private readonly IMapper mapper;

        public AdvertisementService(AutomotiveMarketSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AdvertisementDto>> GetAds()
        {
            var allAds = await this.context.Advertisements.ToListAsync();
            var result = this.mapper.Map<List<AdvertisementDto>>(allAds);
            return result;
        }

        public async Task<AdvertisementDto> AddAdvertisement(AdvertisementDto dto)
        {
            var newAd = this.mapper.Map<Advertisement>(dto);
            var adExists = await this.context.Advertisements.ContainsAsync(newAd);
            if (adExists)
            {
                throw new ArgumentException($"There is already such ad in the db!");
            }

            var adId = await GetNextValue();
            newAd.Id = adId;

            newAd.PublishDate = DateTime.Now;

            await this.context.Advertisements.AddAsync(newAd);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<AdvertisementDto>(newAd);
        }

        public async Task<int> GetNextValue()
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
