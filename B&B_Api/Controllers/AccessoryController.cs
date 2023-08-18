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
            var accessories = await _context.RoomAccessories.ToListAsync();
            if (accessories == null)
            {
                return NotFound();
            }
            return accessories;
        }

        [HttpPost]
        [Route("AddAccessory")]
        public async Task<ActionResult<DbRoomAccessory>> AddAccessory(List<DbRoomAccessory> accessories)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(string id)
        {
            return NotFound();
        }
    }
}
