using B_B_ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace B_B_api.Data
{
    public class DatabaseContext :DbContext 
    {
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbContract> Contracts { get; set; }
        public DbSet<DbLocation> Locations { get; set; }
        public DbSet<DbRoom> Rooms { get; set; }
        public DbSet<DbRoomAccessory> RoomAccessories { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            //DatabaseContext.Database.GetService<IRelationalDatabaseCreator>().Exists();
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
 