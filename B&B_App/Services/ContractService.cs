using B_B_ClassLibrary.BusinessModels;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;

namespace B_B_App.Services
{
    public class ContractService : IContractService<Contract>
    {
        private static HttpClient _httpClient;
        public ContractService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Contract>> GetUserContracts(int id)
        {
            var returnedContracts = await _httpClient.GetFromJsonAsync<List<Contract>>($"Contract/GetUserContracts{id}");
            return returnedContracts;
        }

        public async Task<List<Contract>> GetPendingContracts(int id)
        {
            var pendingContracts = await _httpClient.GetFromJsonAsync<List<Contract>>($"Contract/GetPendingContracts{id}");
            return pendingContracts;
        }

        public async Task<List<Contract>> GetRejectedContracts(int id)
        {
            var approvedCotnracts = await _httpClient.GetFromJsonAsync<List<Contract>>($"Contract/GetRejectedContracts{id}");
            return approvedCotnracts;
        }

        public async Task<List<Contract>> Create(List<Contract> contracts)
        {
            var response = await _httpClient.PostAsJsonAsync("Contract/CreateContracts", contracts);
            var content = await response.Content.ReadAsStringAsync();
            var returnedContracts = JsonSerializer.Deserialize<List<Contract>>(content);
            return returnedContracts;
        }

        public async Task<Contract> Create(Contract contract)
        {
            var returnedContract = await _httpClient.PostAsJsonAsync("Contract/CreateContract", contract);
            var data = await returnedContract.Content.ReadFromJsonAsync<Contract>();
            return data;
        }

        public async Task<bool> Delete(Contract contract)
        {
            var response = await _httpClient.PostAsJsonAsync<Contract>("Contract/DeleteContract", contract);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public async Task<Contract> Get(int id)
        {
            var returnedContract = await _httpClient.GetFromJsonAsync<Contract>($"Contract/GetConract{id}");
            return returnedContract;
        }

        public async Task<Contract> Update(Contract contract)
        {
            var updatedContract = await _httpClient.PostAsJsonAsync<Contract>("Contract/UpdateContract", contract);
            var data = await updatedContract.Content.ReadFromJsonAsync<Contract>();
            return data;
        }
    }
}
