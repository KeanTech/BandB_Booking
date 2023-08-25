using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.BusinessModels
{
    public class Location
    {
        public int Id { get; set; }
        public int LandlordId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int AmountOfRooms { get; set; }
        [Required]
        public string? Area { get; set; }
        public double? Rating { get; set; }
        public Location()
        {

        }
    }
}
