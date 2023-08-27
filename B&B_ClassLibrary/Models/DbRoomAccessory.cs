using B_B_ClassLibrary.BusinessModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_B_ClassLibrary.Models
{
    [Table("RoomAccessory")]
    public class DbRoomAccessory
    {
        [Key]
        public int Id { get; set; }
        public Accessory Type { get; set; }

        public virtual ICollection<DbRoom> ?Rooms { get; set; }

        public DbRoomAccessory()
        {
                
        }

        public DbRoomAccessory(RoomAccessory accessory)
        {
            Id = accessory.Id;
            Type = accessory.Type;
        }
    }

    public static class DbRoomAccessoryExtensions
    {
        public static List<DbRoomAccessory> DbRoomAccessories(this List<RoomAccessory> roomAccessories)
        {
            List<DbRoomAccessory> dbRoomAccessories = new List<DbRoomAccessory>();
            foreach (var item in roomAccessories)
            {
                dbRoomAccessories.Add(new DbRoomAccessory(item));
            }

            return dbRoomAccessories;
        }

        public static List<RoomAccessory> RoomAccessories(this List<DbRoomAccessory> dbRoomAccessories)
        { 
            List<RoomAccessory> roomAccessories = new List<RoomAccessory>();
            foreach(var item in dbRoomAccessories) 
            {
                roomAccessories.Add(new RoomAccessory(item));
            }

            return roomAccessories;
        }

    }
}
