using B_B_ClassLibrary.BusinessModels;
using System.Net.Http.Json;

namespace B_B_App.Services
{
    public class LocationService : ILocationService<Location>
    {
        private static HttpClient _httpClient;
        public RoomService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Location> Create(Location location)
        {
            var returnedLocation = await _httpClient.PostAsJsonAsync<Location>("Location/CreateLocation", location);
            var data = await returnedLocation.Content.ReadFromJsonAsync<Location>();
            return data;
        }

        public Task<HttpResponseMessage> Delete(Location location)
        {
            var response = _httpClient.PostAsJsonAsync<Location>("Location/DeleteLocation", location);
            return response;
        }

        public async Task<Location> Get(int id)
        {
            var returnedLocation = await _httpClient.GetFromJsonAsync<Location>($"Location/GetLocation{id}");
            return returnedLocation;
        }

        public Task<Location> Update(Location type)
        {
            throw new NotImplementedException();
        }
    }
}
