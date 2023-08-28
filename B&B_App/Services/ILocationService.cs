using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface ILocationService<T> : IDataService<T>
    {
        Task<List<Location>> GetLocationsByLandlordId(int landlordId);
    }
}
