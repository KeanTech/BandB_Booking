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

        public async Task<List<RoomAccessory>> GetAllAccessories()
        {
            var allAccessories = await _httpClient.GetFromJsonAsync<List<RoomAccessory>>($"Accessory/GetAllAccessories");
            return allAccessories;
        }
    }
}
