using B_B_App.Services;
using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Core.Managers
{
    public class PictureManager
    {
        private readonly IRoomService<Room> _roomService;
        private readonly IPictureService _pictureService;

        public PictureManager(IRoomService<Room> roomService, IPictureService pictureService)
        {
            _roomService = roomService;
            _pictureService = pictureService;
        }

        public async Task<Dictionary<int, List<Picture>>> GetPictureList()
        {
            Dictionary<int, List<Picture>> pictureList = new Dictionary<int, List<Picture>>();

            var rooms = await _roomService.GetAllRooms();

            foreach (var room in rooms)
            {
                if (pictureList.ContainsKey(room.Id))
                    continue;

                try
                {
                    var roomPictures = await _pictureService.GetRoomPictures(room.Id);
                    if (roomPictures != null)
                        pictureList.Add(room.Id, roomPictures);
                }
                catch (Exception ex)
                {

                }
            }

            return pictureList;
        }

    }
}
