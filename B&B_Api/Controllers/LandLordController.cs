using B_B_api.Data;
using B_B_api.Managers;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LandLordController : Controller
    {
        private readonly BedAndBreakfastContext _context;
        private LoginManager _loginManager = new LoginManager();

        public LandLordController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetLandlord/{Id}")]
        public async Task<ActionResult<DbLandlord>> GetLandlord(int id)
        {
            var landlord = await _context.Landlords.FindAsync(id);
            if (landlord != null)
            {
                return landlord;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("CreateLandlord")]
        public async Task<ActionResult<DbLandlord>> CreateLandlord([FromBody] Landlord landlord)
        {
            if (landlord == null)
            {
                //Checks to see if the username already exists in DB
                if (_loginManager.CheckUsername(landlord.Username, _context))
                {
                    return Conflict("Username already exists");
                }

                DbUser userForLandlord = new DbUser(landlord);
                userForLandlord.PasswordSalt = _loginManager.GenerateSalt();
                userForLandlord.Password = _loginManager.CreateHashedPassword(landlord.Password, userForLandlord.PasswordSalt);
                await _context.Users.AddAsync(userForLandlord);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

                DbLandlord newLandlord = new DbLandlord(landlord);
                newLandlord.UserId = userForLandlord.Id;
                await _context.Landlords.AddAsync(newLandlord);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

                return CreatedAtAction("CreateLandlord", new { id = landlord.Id}, landlord);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("DeleteLandlord")]
        public async Task<ActionResult<DbLandlord>> DeleteLandlord(Landlord landlord)
        {
            var landlordToDelete = _context.Landlords.Where(x => x.Equals(landlord)).FirstOrDefault();
            if (landlordToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _context.Landlords.Remove(landlordToDelete);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok();
            }
        }

        [HttpPost]
        [Route("UpdateLandlord")]
        public async Task<ActionResult<DbLandlord>> UpdateLandlord(Landlord landlord)
        {
            var landlordToUpdate = _context.Landlords.Where(x => x.Id == landlord.Id).FirstOrDefault();
            if (landlordToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                landlordToUpdate.AccountNumber = landlord.AccountNumber;
                landlordToUpdate.RegistrationNumber = landlord.RegistrationNumber;
                landlordToUpdate.CPRNumber = landlord.CPRNumber;
                _context.Update(landlordToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok();
            }
        }
    }
}
