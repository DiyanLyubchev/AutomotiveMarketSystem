using AutomotiveMarketSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace AutomotiveMarketSystem.Data.Seed
{
    public static class CarModelsSeed
    {
        public static void SeedModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().HasData(CreateCarModels());
        }

        public static CarModel[] CreateCarModels()
        {
            string carModels = File.ReadAllText(@"..\AutomotiveMarketSystem.Data\Seed\CarModelsSeed.json");

            var carModelsProvider = JsonConvert.DeserializeObject<CarModel[]>(carModels);

            return carModelsProvider.ToArray();
        }
    }
}

