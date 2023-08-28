using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface ILoginService
    {
        public Task<User> Login(string username, string password);
    }
}
