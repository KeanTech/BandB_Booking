using B_B_ClassLibrary.BusinessModels;
using System.Net.Http.Json;

namespace B_B_App.Services
{
    public class PictureService : IPictureService
    {
        private static HttpClient _httpClient;
        public PictureService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Picture>> AddLocationPictures(List<Picture> pictures)
        {
            var returnedPictures = await _httpClient.PostAsJsonAsync<List<Picture>>("Picture/AddLocationPictures", pictures);
            var data = await returnedPictures.Content.ReadFromJsonAsync<List<Picture>>();
            return data;
        }

        public async Task<List<Picture>> AddRoomPictures(List<Picture> pictures)
        {
            var returnedPictures = await _httpClient.PostAsJsonAsync<List<Picture>>("Picture/AddRoomPictures", pictures);
            return null;
        }

        public async Task<bool> DeleteLocationPictures(List<Picture> pictures)
        {
            var response = await _httpClient.PostAsJsonAsync("Picture/DeleteLocationPictures", pictures);
            if(response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<bool> DeleteRoomPictures(List<Picture> pictures)
        {
            var response = await _httpClient.PostAsJsonAsync("Picture/DeleteRoomPictures", pictures);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<List<Picture>> GetLocationPictures(int locationId)
        {
            var returnedPictures = await _httpClient.GetFromJsonAsync<List<Picture>>($"Picture/GetLocationPictures/{locationId}");
            return returnedPictures;
        }

        public async Task<List<Picture>> GetRoomPictures(int roomId)
        {
            var returnedPictures = await _httpClient.GetFromJsonAsync<List<Picture>>($"Picture/GetRoomPictures/{roomId}");
            return returnedPictures;
        }
    }
}
