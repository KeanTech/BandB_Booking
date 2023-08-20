﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbRoomPicture
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DbRoom")]
        public int RoomId { get; set; }
        public string Base64 { get; set; }

        public ICollection<DbRoom> ?Rooms { get; set; }
    }
}
