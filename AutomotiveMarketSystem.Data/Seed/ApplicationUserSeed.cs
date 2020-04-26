using AutomotiveMarketSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomotiveMarketSystem.Data.Seed
{
    public static class ApplicationUserSeed
    {
        public static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserRole>()
                .HasData(CreateRoles());

            var hasher = new PasswordHasher<User>();

            var adminDiyan = new User
            {
                Id = "c23c3678-6194-4b7e-a928-09614190eb62",
                UserName = "Diyan",
                NormalizedUserName = "DIYAN",
                Email = "admin1@admin.com",
                NormalizedEmail = "ADMIN1@ADMIN.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                LockoutEnabled = true
            };
            var adminIvan = new User
            {
                Id = "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                Email = "admin2@admin.com",
                NormalizedEmail = "ADMIN2@ADMIN.COM",
                SecurityStamp = "74CLJEIXNYLPRXMVXXNSWXZH6R6KJRRU",
                LockoutEnabled = true
            };

            adminDiyan.PasswordHash = hasher.HashPassword(adminDiyan, "123456");
            adminIvan.PasswordHash = hasher.HashPassword(adminIvan, "234567");
            modelBuilder.Entity<User>().HasData(adminDiyan, adminIvan);

            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    UserId = adminDiyan.Id,
                    RoleId = "ca678235-7571-4177-984f-e9d1957b0187"
                },
                  new IdentityUserRole<string>
                  { UserId = adminIvan.Id, RoleId = "ca678235-7571-4177-984f-e9d1957b0187" });
        }

        private static UserRole[] CreateRoles()
        {

            var userRole = new UserRole[]
            {
                 new UserRole
                 {

                     Id = "ca678235-7571-4177-984f-e9d1957b0187",
                     Name = "Admin",
                     NormalizedName = "ADMIN"
                 },
            };
            return userRole;
        }
    }
}
