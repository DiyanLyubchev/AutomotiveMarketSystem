using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutomotiveMarketSystem.Data
{
    public class AutomotiveMarketSystemContext : IdentityDbContext<User>
    {
        public AutomotiveMarketSystemContext()
        {
        }

        public AutomotiveMarketSystemContext(DbContextOptions<AutomotiveMarketSystemContext> options)
          : base(options)
        {
        }

        public virtual DbSet<Advertisement> Advertisements { get; set; }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<EngineTypeStatus> StatusEngines { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>(entity =>
            {
                entity.ToTable("CAR");

                entity.HasKey(key => key.Id);

                entity.Property(brand => brand.CarBrandId)
                    .HasColumnName("CARBRANDID")
                    .HasColumnType("NUMBER(10)");

                entity.Property(engine => engine.EngineTypeId)
                  .HasColumnName("ENGINETYPEID")
                  .HasColumnType("NUMBER(10)");

                entity.Property(engine => engine.Door)
                 .HasColumnName("DOOR")
                 .HasColumnType("NUMBER(10)");

                entity.Property(year => year.ProductionYear)
                 .HasColumnName("PRODUCTIONYEAR")
                 .HasColumnType("DATE");

                entity.Property(engine => engine.Price)
                 .HasColumnName("PRICE")
                 .HasColumnType("NUMBER");

                entity.HasOne(adv => adv.Advertisement)
                .WithOne(car => car.Car);

                entity.HasOne(brand => brand.CarBrand)
                .WithMany(x => x.Cars)
                .HasForeignKey(keybr => keybr.CarBrandId);


                entity.HasOne(engineType => engineType.EngineType)
                .WithMany(car => car.Cars)
                .HasForeignKey(fKey => fKey.EngineTypeId);
            });


            builder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("ADVERTISEMENTS");

                entity.HasKey(key => key.Id);

                entity.Property(carId => carId.CarId)
                 .HasColumnName("CARID")
                 .HasColumnType("NUMBER(10)");

                entity.HasOne(user => user.User)
                .WithMany(adv => adv.Advertisements);

                entity.HasOne(car => car.Car)
                .WithOne(adv => adv.Advertisement);
            });

            builder.Entity<EngineTypeStatus>(entity =>
            {
                entity.ToTable("ENGINETYPESTATUS");

                entity.HasKey(key => key.Id);

                entity.Property(etype => etype.EngineType)
                    .HasColumnName("ENGINETYPE")
                    .HasColumnType("VARCHAR2(50)");

                entity.HasMany(car => car.Cars).WithOne(type => type.EngineType);
            });

            builder.Entity<CarBrand>(entity =>
            {
                entity.ToTable("CARBRAND");

                entity.HasKey(key => key.Id);

                entity.Property(name => name.BrandName)
                 .HasColumnName("BRANDNAME")
                 .HasColumnType("VARCHAR2(50)");

                entity.HasMany(brandModels => brandModels.BrandModels)
                .WithOne(brand => brand.CarBrand);

                entity.HasMany(cars => cars.Cars)
                .WithOne(brand => brand.CarBrand);
            });

            builder.Entity<CarModel>(entity =>
            {
                entity.ToTable("CARMODEL");

                entity.HasKey(key => key.Id);

                entity.Property(name => name.ModelName)
                 .HasColumnName("MODELNAME")
                 .HasColumnType("VARCHAR(50)");

                entity.Property(name => name.CarBrandId)
                .HasColumnName("CARBRANDID")
                .HasColumnType("NUMBER(10)");

                entity.HasOne(brand => brand.CarBrand)
                .WithMany(brand => brand.BrandModels)
                .HasForeignKey(foregnKeybran => foregnKeybran.CarBrandId);

            });

            builder.SeedUserRoles();
            builder.SeedEngine();
            builder.SeedBrands();
            builder.SeedModels();
            base.OnModelCreating(builder);
        }
    }
}
