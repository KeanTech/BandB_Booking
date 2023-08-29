using B_B_App.Services;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace B_B_App.Core.Managers
{
    public class LoginManager
    {
        private readonly IUserService<User> _userService;
        private readonly ILandlordService<Landlord> _landlordService;
        private readonly ILoginService _loginService;

        public LoginManager(IUserService<User> userService, ILandlordService<Landlord> landlordService, ILoginService loginService)
        {
            _userService = userService;
            _landlordService = landlordService;
            _loginService = loginService;
        }
        public static User? User { get; private set; }
        private Landlord? _landlord = null;
        public static void Login()
        {

            if (User == null)
                throw new Exception("User cant be null");

            if (string.IsNullOrEmpty(User.Email) || string.IsNullOrEmpty(User.Password))
                throw new Exception("Email or Password cant be null");
        }

        public async Task UserLogin(string username, string password)
        {
            var user = await _loginService.Login(username, password);
            if (string.IsNullOrEmpty(user.FirstName) == false)
                User = user;

            Login();
            var landLord = await _landlordService.Get(User.Id);
            
            if (landLord == null)
                return;

            _landlord = landLord;
        }

        public Landlord? LandLord() => _landlord != null ? _landlord : new Landlord();
        public bool IsLandLord() => _landlord != null ? true : false;

    }
}
