using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public RatingController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetRoomRatings/{id}")]
        public async Task<ActionResult<IEnumerable<DbRoomRating>>> GetRoomRatings(int id)
        {
            var accessories = await _context.RoomRatings.Where(x => x.RoomId == id).ToListAsync();
            if (accessories == null)
            {
                return NotFound();
            }
            else
            {
                return accessories;
            }
        }

        [HttpGet]
        [Route("GetLocationRatings/{id}")]
        public async Task<ActionResult<IEnumerable<DbLocationRating>>> GetLocationRatings(int id)
        {
            var accessories = await _context.LocationRatings.Where(x => x.LocationId == id).ToListAsync();
            if (accessories == null)
            {
                return NotFound();
            }
            else
            {
                return accessories;
            }
        }

        [HttpPost]
        [Route("CreateRoomRating")]
        public async Task<ActionResult<DbRoomRating>> CreateRoomRating(Rating rating)
        {
            try
            {
                if (rating == null)
                {
                    return BadRequest();
                }
                DbRoomRating newRating = new DbRoomRating(rating);
                await _context.RoomRatings.AddAsync(newRating);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("CreateLocationRating")]
        public async Task<ActionResult<DbLocationRating>> CreateLocationRating(Rating rating)
        {
            try
            {
                if (rating == null)
                {
                    return BadRequest();
                }
                DbLocationRating newRating = new DbLocationRating(rating);
                await _context.LocationRatings.AddAsync(newRating);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("DeleteRoomRating/{id}")]
        public async Task<ActionResult<DbRoomRating>> DeleteRoomRatings(int id)
        {
            
            try
            {
                return NotFound();
            }
            catch (Exception)
            {

                throw;
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
