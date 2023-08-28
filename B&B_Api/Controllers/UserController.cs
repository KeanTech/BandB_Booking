using B_B_api.Data;
using B_B_api.Managers;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B_B_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly BedAndBreakfastContext _context;
        private LoginManager _loginManager = new LoginManager();

        public UserController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<ActionResult<DbUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<DbUser>>> GetUsers()
        {
            var user = await _context.Users.ToListAsync();

            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<DbUser>> CreateUser([FromBody] User user)
        {
            if (user != null)
            {
                //Checks if username already exists in DB
                if (_loginManager.CheckUsername(user.Username, _context))
                {
                    return Conflict("Username already exists");
                }

                DbUser newUser = new DbUser(user);
                newUser.PasswordSalt = _loginManager.GenerateSalt();
                newUser.Password = _loginManager.CreateHashedPassword(user.Password, newUser.PasswordSalt);
                await _context.Users.AddAsync(newUser);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return CreatedAtAction("CreateUser", new { id = user.Id }, user);
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<ActionResult<DbUser>> DeleteUser(User user)
        {
            var userToDelete = await _context.Users.FindAsync(user.Id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _context.Users.Remove(userToDelete);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest();
                }

                return Ok();
            }
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult<DbUser>> UpdateUser(User user)
        {
            var userToUpdate = _context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.Email = user.Email;
                userToUpdate.Country = user.Country;
                userToUpdate.LastName = user.LastName;
                userToUpdate.PhoneNumber = user.PhoneNumber;
                _context.Update(userToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return Ok();
        }
    }
}
