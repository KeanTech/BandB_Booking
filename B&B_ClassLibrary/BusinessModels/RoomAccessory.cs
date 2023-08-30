using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B_B_ClassLibrary.Enums;
using B_B_ClassLibrary.Models;

namespace B_B_ClassLibrary.BusinessModels
{
    public class RoomAccessory
    {
        public int Id { get; set; }
        public Accessory Type { get; set; }

        public RoomAccessory()
        {
            
        }

        public RoomAccessory(DbRoomAccessory accessory)
        {
            Id = accessory.Id;
            Type = accessory.Type;
        }

    }
}
