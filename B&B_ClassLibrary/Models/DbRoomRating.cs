using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbRoomRating
    {
        [Key]
        public int Id { get; set; }
        public double ?Rating { get; set; }

        public DbRoom ?Room { get; set; }

    }
}
