using B_B_ClassLibrary.BusinessModels;
using NPOI.OpenXmlFormats;
using System.Net;
using System.Net.Http.Json;

namespace B_B_App.Services
{
    public class AccessoryService : IAccessoryService
    {
        private static HttpClient _httpClient;
        public AccessoryService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<RoomAccessory> Create(RoomAccessory type)
        {
            var response = await _httpClient.PostAsJsonAsync("Accessory/Create", type);
            if(response.StatusCode != HttpStatusCode.OK)
                return new RoomAccessory();

            var content = await response.Content.ReadFromJsonAsync<RoomAccessory>();
            
            return content ?? new RoomAccessory();
        }

        public Task<bool> Delete(RoomAccessory type)
        {
            throw new NotImplementedException();
        }

        public Task<RoomAccessory> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoomAccessory>> GetAllAccessories()
        {
            var allAccessories = await _httpClient.GetFromJsonAsync<List<RoomAccessory>>($"Accessory/GetAllAccessories");
            return allAccessories;
        }
    }
}
