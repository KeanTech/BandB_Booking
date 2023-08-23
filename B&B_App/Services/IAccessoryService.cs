using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface IAccessoryService
    {
        public Task<List<RoomAccessory>> GetAllAccessories();
    }
}
