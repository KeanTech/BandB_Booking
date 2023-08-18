using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface IRoomService<T> : IDataService<T>
    {
        public Task<List<T>> GetRooms(int id);
        public Task<List<T>> GetAllRooms();
    }
}
