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
        public IActionResult GetRoomPictures(int roomId)
        {
            var pictures = _context.RoomPictures.Where(x => x.RoomId == roomId).ToList();
            if (pictures.Any())
                return Ok(pictures);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetLocationPictures/{locationId}")]
        public IActionResult GetLocationPictures(int locationId)
        {
            var test = _context.LocationPictures.ToList();
            var pictures = _context.LocationPictures.Where(x => x.LocationId == locationId).ToList();
            if (pictures.Any())
                return Ok(pictures);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("AddRoomPictures")]
        public IActionResult AddRoomPictures(List<Picture> pictures)
        {
            foreach (var picture in pictures)
            {
                DbRoomPicture newPicture = new DbRoomPicture(picture);
                _context.RoomPictures.Add(newPicture);
                try
                {
                    _context.SaveChanges();
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
        public IActionResult AddLocationPictures(List<Picture> pictures)
        {
            foreach (var picture in pictures)
            {
                DbLocationPicture newPicture = new DbLocationPicture(picture);
                _context.LocationPictures.Add(newPicture);
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("DeleteRoomPictures/{Id}")]
        public IActionResult DeleteRoomPictures(int roomId)
        {
            var picsToRemove = _context.RoomPictures.Where(x => x.RoomId == roomId).ToList();
            if (picsToRemove != null)
            {
                try
                {
                    _context.RemoveRange(picsToRemove);

                    _context.SaveChanges();
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
        [Route("DeleteLocationPictures/{Id}")]
        public IActionResult DeleteLocationPictures(int locationId)
        {
            var picsToRemove = _context.LocationPictures.Where(x => x.LocationId == locationId).ToList();
            if (picsToRemove != null)
            {
                
                try
                {
                    _context.RemoveRange(picsToRemove);

                    _context.SaveChanges();
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
