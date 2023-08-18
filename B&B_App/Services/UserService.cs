using B_B_ClassLibrary.BusinessModels;
using System.Net.Http.Json;

namespace B_B_App.Services
{
    public class UserService : IUserService<User>
    {
        private static HttpClient _httpClient;
        public UserService(HttpClient client) 
        {
            _httpClient = client;
        }

        public async Task<User> Create(User user)
        {
            var returnedUser = await _httpClient.PostAsJsonAsync<User>("https://localhost:7135/api/CreateUser", user);
            var data = await returnedUser.Content.ReadFromJsonAsync<User>();
            return data;
        }

        public async Task<User> Delete(User user)
        {
            var response = await _httpClient.PostAsJsonAsync<User>("https://localhost:7135/api/DeleteUser", user);
            var data = await response.Content.ReadFromJsonAsync<User>();
            return data;
        }

        public async Task<User> Get(int id)
        {
            var returnedUser = await _httpClient.PostAsJsonAsync<int>("https://localhost:7135/api/GetUser", id);
            var data = await returnedUser.Content.ReadFromJsonAsync<User>();
            return data;
        }

        public async Task<User> Update(User user)
        {
            var updatedUser = await _httpClient.PostAsJsonAsync<User>("https://localhost:7135/api/UpdateUser", user);
            var data = await updatedUser.Content.ReadFromJsonAsync<User>();
            return data;
        }
    }
}
