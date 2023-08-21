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
        public Task<HttpResponseMessage> DeleteRoomPictures(int roomId);
        public Task<HttpResponseMessage> DeleteLocationPictures(int locationId);
    }
}
