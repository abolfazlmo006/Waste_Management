global using Waste_Management.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Waste_Management.Data
{
    public class Waste_ManagementDbContext : IdentityDbContext
    {
        public Waste_ManagementDbContext(DbContextOptions<Waste_ManagementDbContext> options) : base(options)
        {
            
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MunicipalityEntity> Municipalities { get; set; }
        public DbSet<SupervisorEntity> Supervisors { get; set; }
        public DbSet<ContractorEntity> Contractors { get; set; }
        public DbSet<BoothEntity> Booths { get; set; }
        public DbSet<ExhibitorEntity> Exhibitors { get; set; }
        public DbSet<WasteEntity> Wastes { get; set; }
        public DbSet<User_Request_Exhibitor> User_Request_Exhibitors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            var hasher = new PasswordHasher<UserEntity>();

            builder.Entity<UserEntity>()
                .HasData(new UserEntity()
                {
                    Id = "09904fa6-e275-452f-8765-deb3adc5b98f",
                    Age = 18,
                    UserName = "@AbolfazlAdmin",
                    Full_Name = "Abolfazl mohamadi",
                    NormalizedUserName = "@ABOLFAZLADMIN",
                    Email = "abolfazlmohamadi690@gmail.com",
                    NormalizedEmail = "ABOLFAZLMOHAMADI690@GMAIL.COM",
                    EmailConfirmed = true,

                    PasswordHash = hasher.HashPassword(null, "Abolfazl@123")
                }) ;
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = "8951853e-e4a5-44f6-a3ca-6e44c8c8131e"
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "e23802e7-7da3-49dc-b114-839d3659fd8e"
                },
                new IdentityRole()
                {
                    Name = "Contractor",
                    NormalizedName = "CONTRACTOR",
                    Id = "710dd155-54ff-42ef-b664-0d4152af0a7b"
                },
                new IdentityRole()
                {
                    Name = "Exhibitor",
                    NormalizedName = "EXHIBITOR",
                    Id = "77da59e3-5f0d-4362-91be-fcc3d774a908"
                },
                new IdentityRole()
                {
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR",
                    Id = "1302e202-53da-466e-9014-8702745aac51"
                },
                new IdentityRole()
                {
                    Name = "Owner",
                    NormalizedName = "OWNER",
                    Id = "64d3c8a7-c8a2-4de9-b0c3-6d75855a6e26"
                });
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = "64d3c8a7-c8a2-4de9-b0c3-6d75855a6e26",
                UserId = "09904fa6-e275-452f-8765-deb3adc5b98f"
            });

            base.OnModelCreating(builder);
        }
    }
}
