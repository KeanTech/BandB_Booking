using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

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

        public async Task<Dictionary<Room, List<Picture>>> GetAllRoomsAndPictures()
        {
            Dictionary<Room, List<Picture>> roomWithPictures = new Dictionary<Room, List<Picture>>();

            try
            {
                var response = await _httpClient.GetAsync("Room/GetAllRoomsAndPictures");
                var content = await response.Content.ReadAsStringAsync();
                var allRooms = JsonSerializer.Deserialize<List<DbRoom>>(content);
                
                if (allRooms != null)
                    foreach (var item in allRooms)
                    {
                        roomWithPictures.Add(new Room(item), item.Pictures != null ? item.Pictures.ToList().ConvertToPictures() : new List<Picture>());
                    }

            }
            catch (Exception ex)
            {

                var message = ex.Message;
            }

            return roomWithPictures;
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
            var returnedRoom = await _httpClient.GetFromJsonAsync<Room>($"Room/GetRoom/{id}");
            //var data = await returnedRoom.Content.ReadFromJsonAsync<Room>();
            return returnedRoom;
        }

        public async Task<Room> Update(Room room)
        {
            var returnedRoom = await _httpClient.PostAsJsonAsync<Room>("Room/UpdateRoom", room);
            var data = await returnedRoom.Content.ReadFromJsonAsync<Room>();
            return data;
        }
        public async Task<bool> Delete(Room room)
        {
            var response = await _httpClient.PostAsJsonAsync<Room>("Room/DeleteRoom", room);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
