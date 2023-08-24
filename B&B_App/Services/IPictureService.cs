using B_B_App.Services;
using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface IPictureService
    {
        public Task<List<Picture>> AddRoomPictures(List<Picture> pictures);
        public Task<List<Picture>> AddLocationPictures(List<Picture> pictures);
        public Task<List<Picture>> GetRoomPictures(int roomId);
        public Task<List<Picture>> GetLocationPictures(int locationId);
        public Task<bool> DeleteRoomPictures(List<Picture> pictures);
        public Task<bool> DeleteLocationPictures(List<Picture> pictures);
    }
}
