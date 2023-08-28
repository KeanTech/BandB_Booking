

using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface IContractService<T> : IDataService<T>
    {
        public Task<Contract> Create(List<Contract> contracts);
    }
}
