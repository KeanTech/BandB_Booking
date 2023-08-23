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
    public class DbRoomRating
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DbRoom")]
        public int RoomId { get; set; }
        public double ?Rating { get; set; }

        public DbRoomRating()
        {
            
        }

        public DbRoomRating(Rating rating)
        {
            Id = rating.Id;
            RoomId = rating.TypeId;
            Rating = rating.Value;
        }

        public DbRoom ?Room { get; set; }

    }
}
