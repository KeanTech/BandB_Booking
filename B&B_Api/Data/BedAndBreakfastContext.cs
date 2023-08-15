using B_B_ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace B_B_api.Data
{
    public class BedAndBreakfastContext :DbContext 
    {
        public BedAndBreakfastContext(DbContextOptions<BedAndBreakfastContext> options): base(options)
        {
            //BedAndBreakfastContext.Database.GetService<IRelationalDatabaseCreator>().Exists();
            //Database.SetInitializer<BedAndBreakfastContext>(new CreateDatabaseIfNotExists<BedAndBreakfastContext>());

        }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbLandlord> Landlords { get; set; }
        public DbSet<DbContract> Contracts { get; set; }
        public DbSet<DbLocation> Locations { get; set; }
        public DbSet<DbRoom> Rooms { get; set; }
        public DbSet<DbRoomAccessory> RoomAccessories { get; set; }
        public DbSet<DbLocationRating> LocationRatings { get; set; }
        public DbSet<DbRoomRating> RoomRatings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DbRoom>().HasMany(x => x.Ratings);
            modelBuilder.Entity<DbLocation>().HasMany(x => x.Ratings);
        }
    }
}
 