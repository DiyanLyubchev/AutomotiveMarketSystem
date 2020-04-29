using AutomotiveMarketSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace AutomotiveMarketSystem.Data.Seed
{
    public static class CarBrandsSeed
    {
        public static void SeedBrands(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>().HasData(CreateCarBrand());
        }

        public static CarBrand[] CreateCarBrand()
        {
            string carBrands = File.ReadAllText(@"..\AutomotiveMarketSystem.Data\Seed\CarBrandsSeed.json");

            var carBrandsProvider = JsonConvert.DeserializeObject<CarBrand[]>(carBrands);

            return carBrandsProvider.ToArray();

            // var models = carBrandsProvider.Select(x=>x.BrandModels).ToList();
        }
    }
}
