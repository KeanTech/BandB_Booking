using B_B_ClassLibrary.BusinessModels;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

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
            Location? location = new Location();
            var response = await _httpClient.GetAsync($"Location/GetLocation/{id}");
            var content = await response.Content.ReadFromJsonAsync<Location>();
            
            if (content == null)
                return new Location();
            
            return content;
        }

        public async Task<List<Location>> GetLocationsByLandlordId(int landlordId)
        {
            var returnedLocation = await _httpClient.GetFromJsonAsync<List<Location>>($"Location/GetLocationByLandlordId/{landlordId}");
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
