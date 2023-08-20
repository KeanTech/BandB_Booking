using B_B_ClassLibrary.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbLocation
    {
        [Key]
        public int Id { get; set; }
        public int LandlordId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public int AmountOfRooms { get; set; }
        public string ?Area { get; set; }
        public double ?Rating { get; set; }

        public DbLocation()
        {
            
        }

        public DbLocation(Location location)
        {
            Id = location.Id;
            LandlordId = location.LandlordId;

        }

        public DbLandlord ?Landlord { get; set; }
        public ICollection<DbRoom> ?Rooms { get; set; }
        public ICollection<DbLocationRating> ?Ratings { get; set; }
        public ICollection<DbLocationPicture> Pictures { get; set; }
    }
}
