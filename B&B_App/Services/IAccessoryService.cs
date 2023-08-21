using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface IAccessoryService<T> : IDataService<T>
    {
        public Task<List<RoomAccessory>> GetAllAccessories();
    }
}
