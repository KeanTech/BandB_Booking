using B_B_App.Services;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;

namespace B_B_App.Core.Managers
{
    public class LoginManager 
    {
        private readonly IUserService<User> _userService;
        private readonly ILandlordService<DbLandlord> _landlordService;

        public LoginManager(IUserService<User> userService, ILandlordService<DbLandlord> landlordService)
        {
            _userService = userService;
            _landlordService = landlordService;
        }
        public static User User { get; private set; }

        public static void Login(User user) => User = user;

        public static bool IsLandLord(string userId) 
        {


            return true;
        }

        public static bool LandLordOwnsRoom(string roomId) 
        {
            return false;
        }
    }
}
