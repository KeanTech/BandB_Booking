using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    [Table("RoomAccessory")]
    public class DbRoomAccessory
    {
        [Key]
        public int Id { get; set; }
        public RoomAccessory Type { get; set; }

        public ICollection<DbRoom> ?Rooms { get; set; }
    }
}
