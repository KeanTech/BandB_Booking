using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace B_B_api.Controllers
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
            try
            {
                var allRooms = await _context.Rooms.ToListAsync();
                return allRooms;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAllRoomsAndPictures")]
        public IActionResult GetAllRoomsAndPictures()
        {
            try
            {
                var allRooms = _context.Rooms.Include(i => i.Pictures).ToList();
                return Ok(JsonSerializer.Serialize(allRooms));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets the rooms for a specific location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRooms/{locationId}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms(int locationId)
        {
            var allRooms = await _context.Rooms.Where(x => x.LocationId == locationId).ToListAsync();
            return allRooms.ConvertToRooms();
        }

        [HttpGet]
        [Route("GetRoom/{id}")]
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
        public async Task<ActionResult<Room>> CreateRoom(Room room)
        {
            var checkForRoom = _context.Rooms.Where(x => x.Id == room.Id).FirstOrDefault();
            if (checkForRoom == null)
            {
                DbRoom newRoom = new DbRoom(room);
                _context.Rooms.Add(newRoom);
                await _context.SaveChangesAsync();
                room.Id = newRoom.Id;
                return Ok(room);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("DeleteRoom")]
        public async Task<ActionResult<DbRoom>> DeleteRoom(Room room)
        {
            var roomToDelete = await _context.Rooms.FindAsync(room.Id);
            if (roomToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _context.Rooms.Remove(roomToDelete);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPost]
        [Route("UpdateRoom")]
        public async Task<ActionResult<DbRoom>> UpdateRoom(Room room)
        {
            var roomToUpdate = _context.Rooms.Where(x => x.Id == room.Id).FirstOrDefault();
            if (roomToUpdate == null)
            {
                return NotFound();
            }

            else
            {
                roomToUpdate.Number = room.Number;
                roomToUpdate.NumberOfBeds = room.NumberOfBeds;
                roomToUpdate.PricePerNight = room.PricePerNight;

                _context.Update(roomToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok(room);
            }
        }

        [HttpGet]
        [Route("IsRoomOwner")]
        public async Task<ActionResult<bool>> IsRoomOwner(int roomId, int landlordId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            var location = _context.Locations.Where(x => x.Id == room.LocationId).FirstOrDefault();
            if (location.LandlordId == landlordId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        [Route("AddAccessoriesToRoom")]
        public async Task<ActionResult<bool>> AddAccessoriesToRoom(Room room, List<RoomAccessory> roomAccessories) 
        {
            if (room == null)
                return NotFound(false);

            if (roomAccessories.Any() == false)
                return NotFound(false);
            
            DbRoom dbRoom = new DbRoom(room);


            roomAccessories.ForEach((x) => dbRoom.Accessories?.Add(new DbRoomAccessory(x)));

            _context.Rooms.Update(dbRoom);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpGet]
        [Route("GetRoomAccessories/{roomId}")]
        public ActionResult<List<RoomAccessory>> GetRoomAccessories(int roomId) 
        {
            if (roomId == 0)
                return NotFound();

            var roomAccessories = _context.Rooms.FirstOrDefault(x => x.Id == roomId)?.Accessories?.ToList().RoomAccessories();
            
            if(roomAccessories == null)
                return NotFound(new List<RoomAccessory>());

            return roomAccessories;
        }

    }
}