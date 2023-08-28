using Azure.Core;
using B_B_ClassLibrary.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Net;
using System.Net.Cache;

namespace B_B_App.Services
{
    public class LoginService : ILoginService
    {
        private static HttpClient _httpClient;
        public LoginService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<User> Login(string username, string password)
        {
            Credentials credentials = new Credentials(username, password);
            var response = await _httpClient.PostAsJsonAsync<Credentials>("Login/ValidateUser", credentials);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new User();
            }
            var returnedUser = await response.Content.ReadFromJsonAsync<User>();
            if (returnedUser == null)
            {
                return new User();
            }
            return returnedUser;
        }
    }
}
