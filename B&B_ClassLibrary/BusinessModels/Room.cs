using B_B_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.BusinessModels
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int NumberOfBeds { get; set; }
        public int PricePerNight { get; set; }
        public double? Rating { get; set; }

    }
}
