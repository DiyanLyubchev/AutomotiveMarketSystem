using AutomotiveMarketSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public virtual DbSet<EngineTypeStatus> StatusEngines { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>(entity =>
            {

                entity.ToTable("CAR");

                entity.HasKey(key => key.Id);

                entity.Property(carMake => carMake.Make)
                    .HasColumnName("MAKE")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(model => model.CarModel)
                    .HasColumnName("CARMODEL")
                    .HasColumnType("VARCHAR2(50)");

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

                entity.HasOne(engineType => engineType.EngineType).WithOne(car => car.Car);
            });




            base.OnModelCreating(builder);
        }
    }
}
