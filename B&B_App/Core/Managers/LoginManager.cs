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

        public LoginManager(IUserService<User> userService, ILandlordService<Landlord> landlordService)
        {
            _userService = userService;
            _landlordService = landlordService;
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

        public async Task UserLogin()
        {
            var users = await _userService.Get();
            User = users.FirstOrDefault(x => x.Id == 3);

            Login();
            
            var landLord = await _landlordService.Get(User.Id);
            
            if (landLord == null)
                return;

            _landlord = landLord;
        }

        public Landlord? LandLord() => _landlord != null ? _landlord : new Landlord() ;
        public bool IsLandLord() => _landlord != null ? true : false;

    }
}
