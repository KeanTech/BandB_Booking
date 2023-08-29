

using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface IContractService<T> : IDataService<T>
    {
        public Task<HttpResponseMessage> Create(List<Contract> contracts);
        public Task<List<Contract>> GetUserContracts(int id);
        public Task<List<Contract>> GetPendingContracts(int id);
    }
}
