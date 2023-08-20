using B_B_ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace B_B_api.Data
{
    public class BedAndBreakfastContext :DbContext 
    {
        public BedAndBreakfastContext(DbContextOptions<BedAndBreakfastContext> options): base(options)
        {

        }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbLandlord> Landlords { get; set; }
        public DbSet<DbContract> Contracts { get; set; }
        public DbSet<DbLocation> Locations { get; set; }
        public DbSet<DbRoom> Rooms { get; set; }
        public DbSet<DbRoomAccessory> RoomAccessories { get; set; }
        public DbSet<DbLocationRating> LocationRatings { get; set; }
        public DbSet<DbRoomRating> RoomRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>().HasData(
                new DbUser
                {
                    Id = 1,
                    FirstName = "Kenneth",
                    LastName = "Andersen",
                    Email = "ken1ander2@hotmail.com",
                    Country = "Denmark",
                    Created = DateTime.Now,
                    Password = "12345",
                    PhoneNumber = "12345678",
                },
                new DbUser
                {
                    Id = 2,
                    FirstName = "Morten",
                    LastName = "Vestergaard",
                    Email = "mortvest5@gmail.com",
                    Country = "Denmark",
                    Created = DateTime.Now,
                    Password = "12345",
                    PhoneNumber = "11223344",
                },
                new DbUser
                {
                    Id = 3,
                    FirstName = "Buster",
                    LastName = "Jørgensen",
                    Email = "buster@outlook.com",
                    Country = "Denmark",
                    Created = DateTime.Now,
                    Password = "12345",
                    PhoneNumber = "55005500",
                });

            modelBuilder.Entity<DbLandlord>().HasData(
                new DbLandlord
                {
                    Id = 1,
                    UserId = 3,
                    CPRNumber = "0101906673",
                    AccountNumber = "0000222244446666",
                    RegistrationNumber = "6789",
                });

            modelBuilder.Entity<DbLocation>().HasData(
                new DbLocation
                {
                    Id = 1,
                    LandlordId = 1,
                    Name = "Hansens fede Bed and Breakfast",
                    Address = "Havnevej 1",
                    City = "Skagen",
                    ZipCode = "1000",
                    Country = "Denmark",
                    AmountOfRooms = 4,
                    Area = "TestArea",
                    Rating = 4.1
                });

            modelBuilder.Entity<DbRoom>().HasData(
                new DbRoom
                {
                    Id = 1,
                    Number = 1,
                    NumberOfBeds = 2,
                    PricePerNight = 500,
                    Rating = 4,
                    LocationId = 1,
                },
                new DbRoom
                {
                    Id = 2,
                    Number = 2,
                    NumberOfBeds = 2,
                    PricePerNight = 200,
                    Rating = 2,
                    LocationId = 1,
                },
                new DbRoom
                {
                    Id = 3,
                    Number = 3,
                    NumberOfBeds = 1,
                    PricePerNight = 1000,
                    Rating = 5,
                    LocationId = 1,
                },
                new DbRoom
                {
                    Id = 4,
                    Number = 4,
                    NumberOfBeds = 3,
                    PricePerNight = 2000,
                    Rating = 1,
                    LocationId = 1,
                });


            modelBuilder.Entity<DbRoom>().HasMany(x => x.Pictures);
            modelBuilder.Entity<DbRoom>().HasMany(x => x.Ratings);
            modelBuilder.Entity<DbLocation>().HasMany(x => x.Ratings);
            modelBuilder.Entity<DbLocation>().HasMany(x => x.Pictures);

            modelBuilder.Entity<DbContract>()
                .HasOne(x => x.User)
                .WithMany(y => y.Contracts)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
 