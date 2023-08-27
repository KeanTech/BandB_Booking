using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface ILoginService
    {
        public Task<bool> Login(string username, string password);
    }
}
