using B_B_api.Data;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B_B_Api.Controllers
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
    }
}
