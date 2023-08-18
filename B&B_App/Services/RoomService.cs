using B_B_ClassLibrary.BusinessModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace B_B_App.Services
{
    public class RoomService : IRoomService<Room>
    {
        private static HttpClient _httpClient;
        public RoomService(HttpClient client)
        {
            _httpClient = client;
        }


        public async Task<Room> Create(Room room)
        {
            var returnedRoom = await _httpClient.PostAsJsonAsync<Room>("https://localhost:7135/api/CreateRoom", room);
            var data = await returnedRoom.Content.ReadFromJsonAsync<Room>();
            return data;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            var allRooms = await _httpClient.GetFromJsonAsync<List<Room>>("https://localhost:7135/api/GetAllRooms");
            return allRooms;
            
        }

        public async Task<List<Room>> GetRooms(int locationId)
        {
            var locationRooms = await _httpClient.PostAsJsonAsync<int>("https://localhost:7135/api/GetRooms", locationId);
            var returnedLocRooms = await locationRooms.Content.ReadFromJsonAsync<List<Room>>();
            return returnedLocRooms;
        }

        public async Task<Room> Get(int id)
        {
            var returnedRoom = await _httpClient.PostAsJsonAsync<int>("https://localhost:7135/api/GetRoom", id);
            var data = await returnedRoom.Content.ReadFromJsonAsync<Room>();
            return data;
        }

        public async Task<Room> Update(Room room)
        {
            var returnedRoom = await _httpClient.PostAsJsonAsync<Room>("https://localhost:7135/api/UpdateRoom", room);
            var data = await returnedRoom.Content.ReadFromJsonAsync<Room>();
            return data;
        }
        public async Task<Room> Delete(Room room)
        {
            var response = await _httpClient.PostAsJsonAsync<Room>("https://localhost:7135/api/DeleteRoom", room);
            var data = await response.Content.ReadFromJsonAsync<Room>();
            return data;
        }
    }
}
