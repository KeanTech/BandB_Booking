using B_B_ClassLibrary.BusinessModels;
using System.Net;
using System.Net.Http.Json;

namespace B_B_App.Services
{
    public class LandlordService : ILandlordService<Landlord>
    {
        private static HttpClient _httpClient;
        public LandlordService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Landlord> Create(Landlord landlord)
        {
            var returnedLandlord = await _httpClient.PostAsJsonAsync<Landlord>("Landlord/CreateLandlord", landlord);
            var data = await returnedLandlord.Content.ReadFromJsonAsync<Landlord>();
            return data;
        }

        public async Task<bool> Delete(Landlord landlord)
        {
            var response = await _httpClient.PostAsJsonAsync<Landlord>("Landlord/DeleteLandlord", landlord);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Landlord> Get(int userId)
        {
            var returnedLandlord = await _httpClient.GetFromJsonAsync<Landlord>($"Landlord/GetLandlord/{userId}");
            if (returnedLandlord.UserId != null)
                return returnedLandlord;

            return new Landlord();
        }

        public async Task<Landlord> Update(Landlord landlord)
        {
            var updatedLandlord = await _httpClient.PostAsJsonAsync<Landlord>("Landlord/UpdateLandlord", landlord);
            var data = await updatedLandlord.Content.ReadFromJsonAsync<Landlord>();
            return data;
        }
    }
}
