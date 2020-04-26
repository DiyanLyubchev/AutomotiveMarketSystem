using AutomotiveMarketSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveMarketSystem.Data.Seed
{
    public static class SeedEngineType
    {
        public static void SeedEngine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EngineTypeStatus>().HasData(CreateEngineType());

        }

        private static EngineTypeStatus[] CreateEngineType()
        {
            return new EngineTypeStatus[]
            {
                new EngineTypeStatus
                {
                     Id= 1,
                     EngineType="Gas"
                },
                new EngineTypeStatus
                {
                     Id= 2,
                     EngineType="Diesel"
                },
                new EngineTypeStatus
                {
                     Id= 3,
                     EngineType="Electric"
                },
                new EngineTypeStatus
                {
                     Id= 4,
                     EngineType="Hybrid"
                }
            };

        }
    }
}
