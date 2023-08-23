using B_B_ClassLibrary.BusinessModels;
using NPOI.OpenXmlFormats;
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

        public Task<RoomAccessory> Create(RoomAccessory type)
        {
            throw new NotImplementedException();
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
