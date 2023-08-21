using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Core.Managers
{
    public class LoginManager 
    {
        public static User User { get; private set; }

        public static void Login(User user) => User = user;
    
    }
}
