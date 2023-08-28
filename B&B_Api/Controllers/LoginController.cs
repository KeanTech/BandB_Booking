using B_B_api.Data;
using B_B_api.Managers;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace B_B_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly BedAndBreakfastContext _context;
        private LoginManager _loginManager = new LoginManager();

        public LoginController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("ValidateUser")]
        public ActionResult<DbUser> ValidateUser(Credentials credentials)
        {
            if (String.IsNullOrEmpty(credentials.Username) || String.IsNullOrEmpty(credentials.Password))
            {
                return Unauthorized("Login denied, password or username missing");
            }

            if (_loginManager.CheckUsername(credentials.Username, _context))
            {
                var salt = _loginManager.GetSaltFromDB(credentials.Username, _context);

                var hashedPassword = _loginManager.GetHashedPasswordFromDB(credentials.Username, _context);

                if (_loginManager.ValidatePassword(credentials.Password, credentials.Username, salt, hashedPassword)) 
                {
                    var userFromDb = _context.Users.FirstOrDefault(x => x.Username == credentials.Username);
                    User userToReturn = new User(userFromDb);
                    return Ok(userToReturn);
                }
            }
            else
            {
                return NotFound("Username or password incorrect");
            }
            return BadRequest();
        }
    }
}
