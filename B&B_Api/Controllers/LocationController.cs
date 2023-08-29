using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B_B_api.Controllers
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
        [Route("GetAllLocations")]
        public async Task<ActionResult<IEnumerable<DbLocation>>> GetAllLocations()
        {
            var locations = await _context.Locations.ToListAsync();
            return locations;
        }

        [HttpGet]
        [Route("GetLocation/{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(new Location(location));
        }

        [HttpGet]
        [Route("GetLocationByLandlordId/{landlordId}")]
        public async Task<ActionResult<IEnumerable<DbLocation>>> GetLocationByLandlordId(int landlordId)
        {
            var location = (await _context.Locations.ToListAsync()).Where(x => x.LandlordId == landlordId);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        [Route("CreateLocation")]
        public async Task<ActionResult<Location>> CreateLocation(Location location)
        {
            var checkForLocation = _context.Locations.Where(x => x.Id == location.Id).FirstOrDefault();
            if (checkForLocation == null)
            {
                DbLocation newLocation = new DbLocation(location);
                await _context.Locations.AddAsync(newLocation);

                await _context.SaveChangesAsync();
                return Ok(new Location(newLocation));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("DeleteLocation")]
        public async Task<ActionResult<DbLocation>> DeleteLocation(Location location)
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
        [Route("UpdateLocation")]
        public async Task<ActionResult<DbLocation>> UpdateLocation(Location location)
        {
            var locToUpdate = _context.Locations.Where(x => x.Id == location.Id).FirstOrDefault();
            if (locToUpdate != null)
            {
                locToUpdate.Name = location.Name;
                locToUpdate.Address = location.Address;
                locToUpdate.City = location.City;
                locToUpdate.ZipCode = location.ZipCode;
                locToUpdate.Country = location.Country;
                locToUpdate.AmountOfRooms = location.AmountOfRooms;
                locToUpdate.Area = location.Area;

                _context.Locations.Update(locToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return Ok();
        }
    }
}
