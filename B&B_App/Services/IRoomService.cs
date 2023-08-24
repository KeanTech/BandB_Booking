using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface IRoomService<T> : IDataService<T>
    {
        Task<List<T>> GetRooms(int id);
        Task<Dictionary<Room, List<Picture>>> GetAllRoomsAndPictures();
        Task<List<T>> GetAllRooms();
    }
}
