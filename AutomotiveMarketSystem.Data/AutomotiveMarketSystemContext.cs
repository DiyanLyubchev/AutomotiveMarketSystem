using AutomotiveMarketSystem.Data.Models;
using AutomotiveMarketSystem.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

                //entity.Property(carMake => carMake.C)
                //    .HasColumnName("MAKE")
                //    .HasColumnType("VARCHAR2(50)");

                entity.Property(brand => brand.CarBrandId)
                    .HasColumnName("CARBRANDID")
                    .HasColumnType("NUMBER(10)");

                entity.Property(engine => engine.Engine)
                  .HasColumnName("ENGINE")
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

                entity.HasOne(adv => adv.Advertisement).WithOne(car => car.Car);
                entity.HasOne(brand => brand.CarBrand).WithMany(x => x.Cars);
               

                entity.HasOne(engineType => engineType.EngineType).WithOne(car => car.Car);
            });


            builder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("ADVERTISEMENTS");

                entity.HasKey(key => key.Id);

                entity.Property(carId => carId.CarId)
                 .HasColumnName("CARID")
                 .HasColumnType("NUMBER(10)");

                entity.HasOne(user => user.User).WithMany(adv => adv.Advertisements);
            });

            builder.Entity<EngineTypeStatus>(entity =>
            {
                entity.ToTable("ENGINETYPESTATUS");

                entity.HasKey(key => key.Id);

                entity.Property(etype => etype.EngineType)
                    .HasColumnName("ENGINETYPE")
                    .HasColumnType("VARCHAR2(50)");

                entity.HasOne(car=> car.Car).WithOne(type => type.EngineType);
            });

            builder.Entity<CarBrand>(entity =>
            {
                entity.ToTable("CARBRAND");

                entity.HasKey(key => key.Id);

                entity.Property(name => name.BrandName)
                 .HasColumnName("BRANDNAME")
                 .HasColumnType("VARCHAR(50)");

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
                .WithMany(brand => brand.BrandModels);
            });

            //builder.Entity<UserRole>(entity =>
            //{
            //    entity.ToTable("ASPNETROLES");

            //    entity.HasKey(key => key.Id);

            //    entity.Property(etype => etype.Name)
            //        .HasColumnName("NAME")
            //        .HasColumnType("NVARCHAR2(256)");

            //    entity.Property(etype => etype.NormalizedName)
            //       .HasColumnName("NORMALIZEDNAME")
            //       .HasColumnType("NVARCHAR2(256)");
            //});

            builder.SeedUserRoles();
            builder.SeedEngine();
            base.OnModelCreating(builder);
        } 
    }
}
