using B_B_ClassLibrary.BusinessModels;
using System.Net;
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
            var returnedUser = await _httpClient.PostAsJsonAsync<User>("User/CreateUser", user);
            var data = await returnedUser.Content.ReadFromJsonAsync<User>();
            return data;
        }

        public async Task<bool> Delete(User user)
        {
            var response = await _httpClient.PostAsJsonAsync<User>("User/DeleteUser", user);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> Get(int id)
        {
            var returnedUser = await _httpClient.PostAsJsonAsync<int>("User/GetUser", id);
            var data = await returnedUser.Content.ReadFromJsonAsync<User>();
            return data;
        }

        public async Task<List<User>> Get()
        {
            var returnedUser = await _httpClient.GetAsync("User/GetUsers");
            var data = await returnedUser.Content.ReadFromJsonAsync<List<User>>();
            return data;
        }

        public async Task<User> Update(User user)
        {
            var updatedUser = await _httpClient.PostAsJsonAsync<User>("User/UpdateUser", user);
            var data = await updatedUser.Content.ReadFromJsonAsync<User>();
            return data;
        }
    }
}
