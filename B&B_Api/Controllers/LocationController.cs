using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public LocationController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<DbLocation>>> GetAll()
        {
            var locations = await _context.Locations.ToListAsync();
            return locations;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<DbLocation>> Get(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return location;

        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<DbLocation>> Post(Location location)
        {
            var checkForLocation = _context.Locations.Where(x => x.Id == location.Id).FirstOrDefault();
            if (checkForLocation == null)
            {
                DbLocation newLocation = new DbLocation(location);
                await _context.Locations.AddAsync(newLocation);

                await _context.SaveChangesAsync();
                return CreatedAtAction("Create", new { id = newLocation.Id }, newLocation);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<DbLocation>> Delete(Location location)
        {
            var locationToDelete = await _context.Locations.FindAsync(location.Id);
            if (locationToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _context.Locations.Remove(locationToDelete);

                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update()
        {
            return NotFound();
        }
    }
}
