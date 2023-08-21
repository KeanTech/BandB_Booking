using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B_B_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PictureController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public PictureController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetRoomPictures/{roomId}")]
        public async Task<ActionResult<ICollection<DbRoomPicture>>> GetRoomPictures(int roomId)
        {
            var pictures = await _context.RoomPictures.Where(x => x.RoomId == roomId).ToListAsync();
            return Ok(pictures);
        }

        [HttpGet]
        [Route("GetLocationPictures/{locationId}")]
        public async Task<ActionResult<ICollection<DbLocationPicture>>> GetLocationPictures(int locationId)
        {
            var pictures = await _context.LocationPictures.Where(x => x.LocationId == locationId).ToListAsync();
            return Ok(pictures);
        }

        [HttpPost]
        [Route("AddRoomPictures")]
        public async Task<ActionResult<DbRoomPicture>> AddRoomPictures(List<Picture> pictures)
        {
            foreach (var picture in pictures)
            {
                DbRoomPicture newPicture = new DbRoomPicture(picture);
                await _context.RoomPictures.AddAsync(newPicture);
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

        [HttpPost]
        [Route("AddLocationPictures")]
        public async Task<ActionResult<DbLocationPicture>> AddLocationPictures(List<Picture> pictures)
        {
            foreach (var picture in pictures)
            {
                DbLocationPicture newPicture = new DbLocationPicture(picture);
                await _context.LocationPictures.AddAsync(newPicture);
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

        [HttpPost]
        [Route("DeleteRoomPictures")]
        public async Task<ActionResult<DbRoomPicture>> DeleteRoomPictures(int roomId)
        {
            var picsToRemove = _context.RoomPictures.Where(x => x.RoomId == roomId).ToList();
            if (picsToRemove != null)
            {
                try
                {
                    _context.RemoveRange(picsToRemove);

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
                return NotFound();
            }
        }

        [HttpPost]
        [Route("DeleteLocationPictures")]
        public async Task<ActionResult<DbLocationPicture>> DeleteLocationPictures(int locationId)
        {
            var picsToRemove = _context.LocationPictures.Where(x => x.LocationId == locationId).ToList();
            if (picsToRemove != null)
            {
                
                try
                {
                    _context.RemoveRange(picsToRemove);

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
                return NotFound();
            }
        }
    }
}
