using B_B_api.Data;
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

        public LandLordController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetLandlord")]
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
        public async Task<ActionResult<DbLandlord>> CreateLandlord(Landlord landlord)
        {
            var landlordCheck = _context.Landlords.Where(x => x.Id == landlord.Id).FirstOrDefault();
            if (landlordCheck != null)
            {
                DbLandlord newLandlord = new DbLandlord(landlord);
                await _context.AddAsync(newLandlord);
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
