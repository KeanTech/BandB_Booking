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
        [Route("Get")]
        public async Task<ActionResult<DbUser>> Get(int id)
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
        [Route("Create")]
        public async Task<ActionResult<DbUser>> Post(User user)
        {
            var userCheck = _context.Users.Where(x => x.Id == user.Id).SingleOrDefault();

            if (userCheck == null)
            {
                DbUser newUser = new DbUser(user);
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<DbUser>> Delete(DbUser user)
        {
            var userToDelete = _context.Users.Where(x => x.Equals(user)).SingleOrDefault();
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
        [Route("Update")]
        public async Task<ActionResult<DbUser>> Update()
        {
            return NotFound();
        }
    }
}
