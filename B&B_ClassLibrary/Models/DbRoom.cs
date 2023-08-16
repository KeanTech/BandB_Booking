using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbRoom
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DbLocation")]
        public int LocationId { get; set; }
        public int Number { get; set; }
        public int NumberOfBeds { get; set; }
        public int PricePerNight { get; set; }
        public double ?Rating { get; set; }

        public DbLocation ?Location { get; set; }
        public ICollection<DbRoomAccessory> ?Accessories { get; set; }
        public ICollection<DbRoomRating> ?Ratings { get; set; }
    }
}
