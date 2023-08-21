using B_B_App.Services;
using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Core.Managers
{
    public class LoginManager 
    {
        public LoginManager(IUserService userService)
        {
            
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
