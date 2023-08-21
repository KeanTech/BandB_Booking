using B_B_ClassLibrary.BusinessModels;
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

        public Task<Landlord> Delete(Landlord type)
        {
            throw new NotImplementedException();
        }

        public Task<Landlord> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Landlord> Update(Landlord type)
        {
            throw new NotImplementedException();
        }
    }
}
