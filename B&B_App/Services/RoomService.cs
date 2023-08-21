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
            var returnedRoom = await _httpClient.PostAsJsonAsync<Room>("Room/CreateRoom", room);
            var data = await returnedRoom.Content.ReadFromJsonAsync<Room>();
            return data;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            var allRooms = await _httpClient.GetFromJsonAsync<List<Room>>("Room/GetAllRooms");
            return allRooms;
            
        }

        public async Task<List<Room>> GetRooms(int locationId)
        {
            var locationRooms = await _httpClient.PostAsJsonAsync<int>("Room/GetRooms", locationId);
            var returnedLocRooms = await locationRooms.Content.ReadFromJsonAsync<List<Room>>();
            return returnedLocRooms;
        }

        public async Task<Room> Get(int id)
        {
            var returnedRoom = await _httpClient.PostAsJsonAsync<int>("Room/GetRoom", id);
            var data = await returnedRoom.Content.ReadFromJsonAsync<Room>();
            return data;
        }

        public async Task<Room> Update(Room room)
        {
            var returnedRoom = await _httpClient.PostAsJsonAsync<Room>("Room/UpdateRoom", room);
            var data = await returnedRoom.Content.ReadFromJsonAsync<Room>();
            return data;
        }
        public async Task<Room> Delete(Room room)
        {
            var response = await _httpClient.PostAsJsonAsync<Room>("Room/DeleteRoom", room);
            var data = await response.Content.ReadFromJsonAsync<Room>();
            return data;
        }
    }
}
