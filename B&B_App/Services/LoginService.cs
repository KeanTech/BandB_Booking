using B_B_ClassLibrary.BusinessModels;
using System.Net.Http.Json;

namespace B_B_App.Services
{
    public class LoginService : ILoginService
    {
        private static HttpClient _httpClient;
        public LoginService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<bool> Login(string username, string password)
        {
            var loginQuery = $"?username={username}&password={password}";
            var response = await _httpClient.GetFromJsonAsync<HttpResponseMessage>($"/Login" + loginQuery);
            return response.IsSuccessStatusCode;
        }
    }
}
