using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Services
{
    public interface IRatingService
    {
        public Task<Rating> GetRoomRatings(int id);
        public Task<Rating> GetLocationRatings(int id);
        public Task<Rating> CreateRoomRating(Rating rating);
        public Task<Rating> CreateLocationRating(Rating rating);
    }
}
