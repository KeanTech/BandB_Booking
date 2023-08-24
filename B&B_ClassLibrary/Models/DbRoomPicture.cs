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
    public class DbRoomPicture
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DbRoom")]
        public int RoomId { get; set; }
        public string Base64 { get; set; }

        public DbRoomPicture(Picture picture)
        {
            Id = picture.Id;
            RoomId = picture.TypeId;
            Base64 = picture.Base64;
        }
        public DbRoomPicture()
        {

        }

        public DbRoom? Room { get; set; }
    }
    public static class DbRoomPictureExtensions 
    {
        public static List<Picture> ConvertToPictures(this List<DbRoomPicture> pictures)
        {
            List<Picture> roomPictures = new List<Picture>();
            foreach (var item in pictures)
            {
                Picture roomPicture = new Picture() { Id = item.Id, Base64 = item.Base64, TypeId = item.RoomId };
                roomPictures.Add(roomPicture);
            }

            return roomPictures;
        }
        public static List<Picture> ConvertToPictures(this List<DbLocationPicture> pictures)
        {
            List<Picture> roomPictures = new List<Picture>();
            foreach (var item in pictures)
            {
                Picture roomPicture = new Picture() { Id = item.Id, Base64 = item.Base64, TypeId = item.LocationId };
                roomPictures.Add(roomPicture);
            }

            return roomPictures;
        }
        public static List<DbRoomPicture> ConvertToRoomPictures(this List<Picture> pictures) 
        {
            List<DbRoomPicture> roomPictures = new List<DbRoomPicture>();
            foreach (var item in pictures)
            {
                DbRoomPicture roomPicture = new DbRoomPicture(item);
                roomPictures.Add(roomPicture);
            }

            return roomPictures;
        }
        public static List<DbLocationPicture> ConvertToLocationPictures(this List<Picture> pictures)
        {
            List<DbLocationPicture> roomPictures = new List<DbLocationPicture>();
            foreach (var item in pictures)
            {
                DbLocationPicture roomPicture = new DbLocationPicture(item);
                roomPictures.Add(roomPicture);
            }

            return roomPictures;
        }
    }
}
