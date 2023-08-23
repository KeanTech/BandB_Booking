using B_B_ClassLibrary.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbLocationRating
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DbLocation")]
        public int LocationId { get; set; }
        public double ?Rating { get; set; }

        public DbLocationRating()
        {

        }

        public DbLocationRating(Rating rating)
        {
            Id = rating.Id;
            LocationId = rating.TypeId;
            Rating = rating.Value;
        }

        public DbLocation ?Location { get; set; }
    }
}
