using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B_B_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessoryController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public AccessoryController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllAccessories")]
        public async Task<ActionResult<IEnumerable<DbRoomAccessory>>> GetAllAccessories()
        {
            var accessories = await _context.RoomAccessory.ToListAsync();
            if (accessories == null)
            {
                return NotFound();
            }
            return accessories;
        }



        [HttpGet]
        [Route("Create")]
        public async Task<ActionResult<Accessory>> Create(RoomAccessory accessory)
        {
            if (accessory == null)
                return NotFound();

            try
            {
                _context.RoomAccessories.Add(new DbRoomAccessory(accessory));
                await _context.SaveChangesAsync();

                return Ok(accessory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
