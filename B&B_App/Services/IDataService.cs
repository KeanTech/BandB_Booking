namespace B_B_App.Services
{
    public interface IDataService<T>
    {
        public Task<T> Create(T type);
        public Task<T> Get(int id);
        public Task<T> Update(T type);
        public Task<bool> Delete(T type);
    }
}
