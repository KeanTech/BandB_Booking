using B_B_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.BusinessModels
{
    public class Room
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        [DisplayName("Nummer")]
        public int Number { get; set; }
        [DisplayName("Antal senge")]
        public int NumberOfBeds { get; set; }
        [DisplayName("Pris per nat")]
        public int PricePerNight { get; set; }
        [DisplayName("Score")]
        public double? Rating { get; set; }

        public Room()
        {
            
        }

        public Room(DbRoom dbRoom)
        {
            Id = dbRoom.Id;
            LocationId = dbRoom.LocationId;
            Number = dbRoom.Number;
            NumberOfBeds = dbRoom.NumberOfBeds;
            PricePerNight = dbRoom.PricePerNight;
            Rating = dbRoom.Rating;
        }
    }
}
