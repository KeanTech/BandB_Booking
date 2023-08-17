using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public UserController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult<DbUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<DbUser>> CreateUser(User user)
        {
            var userCheck = _context.Users.Where(x => x.Id == user.Id).SingleOrDefault();

            if (userCheck == null)
            {
                DbUser newUser = new DbUser(user);
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
            else
            {
                return BadRequest();
            }
            return Ok();
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
