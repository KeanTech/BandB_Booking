using B_B_api.Data;
using B_B_api.Managers;
using B_B_ClassLibrary.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly BedAndBreakfastContext _context;
        private LoginManager _loginManager;

        public LoginController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login([FromBody]User user)
        {
            if (String.IsNullOrEmpty(user.Username) || String.IsNullOrEmpty(user.Password))
            {
                return Unauthorized("Login denied, password or username missing");
            }

            if (_loginManager.CheckUsername(user.Username, _context))
            {
                var salt = _loginManager.GetSaltFromDB(user.Username, _context);

                var hashedPassword = _loginManager.GetHashedPasswordFromDB(user.Password, _context);

                if (_loginManager.ValidatePassword(user.Password, user.Username, salt, hashedPassword)) 
                {
                    return Ok(true);
                }
            }
            return BadRequest();
        }
    }
}
