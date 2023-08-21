using B_B_App.Services;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;

namespace B_B_App.Core.Managers
{
    public class LoginManager 
    {
        private readonly IUserService<User> _userService;
        private readonly ILandlordService<Landlord> _landlordService;

        public LoginManager(IUserService<User> userService, ILandlordService<Landlord> landlordService)
        {
            _userService = userService;
            _landlordService = landlordService;
        }
        public static User User { get; private set; }

        public static void Login(User user) => User = user;

        public bool IsLandLord(int userId) 
        {
            var landLord = _landlordService.Get(userId);
            if(landLord != null)
                return true;

            return false;
        }

        public static bool LandLordOwnsRoom(string roomId, string landLordId) 
        {
            // use LandlordService here
            return false;
        }
    }
}
