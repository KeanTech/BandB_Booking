using B_B_ClassLibrary.BusinessModels;
using System.Net;
using System.Net.Http.Json;

namespace B_B_App.Services
{
    public class LocationService : ILocationService<Location>
    {
        private static HttpClient _httpClient;
        public LocationService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Location> Create(Location location)
        {
            var returnedLocation = await _httpClient.PostAsJsonAsync<Location>("Location/CreateLocation", location);
            var data = await returnedLocation.Content.ReadFromJsonAsync<Location>();
            return data;
        }

        public async Task<bool> Delete(Location location)
        {
            var response = await _httpClient.PostAsJsonAsync<Location>("Location/DeleteLocation", location);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Location> Get(int id)
        {
            var returnedLocation = await _httpClient.GetFromJsonAsync<Location>($"Location/GetLocation{id}");
            return returnedLocation;
        }

        public async Task<Location> Update(Location location)
        {
            var updatedLocation = await _httpClient.PostAsJsonAsync<Location>("Location/UpdateLocation", location);
            var data = await updatedLocation.Content.ReadFromJsonAsync<Location>();
            return data;
        }
    }
}
