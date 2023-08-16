using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace B_B_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private readonly BedAndBreakfastContext _context;

        public RoomController(BedAndBreakfastContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all rooms mainly for the front page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllRooms")]
        public async Task<ActionResult<IEnumerable<DbRoom>>> GetAllRooms()
        {
            var allRooms = await _context.Rooms.ToListAsync();
            return allRooms;
        }

        /// <summary>
        /// Gets the rooms for a specific location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRooms")]
        public async Task<ActionResult<IEnumerable<DbRoom>>> Get(int locationId)
        {
            var allRooms = await _context.Rooms.Where(x => x.LocationId == locationId).ToListAsync();
            return allRooms;
        }

        [HttpGet]
        [Route("GetRoom")]
        public async Task<ActionResult<DbRoom>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                return room;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("CreateRoom")]
        public async Task<ActionResult<DbRoom>> CreateRoom(Room room)
        {
            var checkForRoom = _context.Rooms.Where(x => x.Id == room.Id).FirstOrDefault();
            if (checkForRoom != null)
            {
                DbRoom newRoom = new DbRoom(room);
                _context.Rooms.Add(newRoom);
                await _context.SaveChangesAsync();
                return CreatedAtAction("CreateRoom", new { id = room.Id }, room);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<DbRoom>> Delete(Room room)
        {
            var roomToDelete = await _context.Rooms.FindAsync(room.Id);
            if (roomToDelete != null)
            {
                _context.Rooms.Remove(roomToDelete);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
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