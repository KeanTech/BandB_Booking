using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbRoomAccessory
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<DbRoom> ?Rooms { get; set; }
    }
}
