using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbLocation
    {
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

        public DbLandlord ?Landlord { get; set; }
        public ICollection<DbRoom> ?Rooms { get; set; }
        public ICollection<DbLocationRating> ?Ratings { get; set; }
    }
}
