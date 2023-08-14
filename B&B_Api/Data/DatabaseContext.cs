using B_B_ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace B_B_api.Data
{
    public class DatabaseContext :DbContext 
    {
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbContract> Contracts { get; set; }
        public DbSet<DbLocation> Locations { get; set; }
        public DbSet<DbRoom> Rooms { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }


    }
}
