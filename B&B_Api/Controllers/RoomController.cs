﻿using B_B_api.Data;
using B_B_ClassLibrary.BusinessModels;
using B_B_ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

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
            try
            {
                var allRooms = await _context.Rooms.Include(x => x.Ratings).Include(y => y.Pictures).Include(i => i.Accessories).ToListAsync();
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
        [Route("GetRooms")]
        public async Task<ActionResult<IEnumerable<DbRoom>>> GetRooms(int locationId)
        {
            var allRooms = await _context.Rooms.Include(x => x.Accessories).Include(y => y.Pictures).Include(i => i.Ratings).Where(x => x.LocationId == locationId).ToListAsync();
            return allRooms;
        }

        [HttpGet]
        [Route("GetRoom/{id}")]
        public async Task<ActionResult<DbRoom>> GetRoom(int id)
        {
            var room = await _context.Rooms.Include(x => x.Accessories).Where(y => y.Id == id).FirstOrDefaultAsync();
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
        public async Task<ActionResult<DbRoom>> CreateRoom([FromBody]Room room)
        {
            var checkForRoom = _context.Rooms.Where(x => x.Id == room.Id).FirstOrDefault();
            List<DbRoomAccessory> newAccList = new List<DbRoomAccessory>();
            foreach (var accessory in room.Accessories) 
            {
                DbRoomAccessory newAcc = new DbRoomAccessory(accessory);
                newAccList.Add(newAcc);
            }

            var allAccessories = _context.RoomAccessory.ToList();
            var accessoryCheck = allAccessories.Where(x => room.Accessories.Any(y => y.Type == x.Type)).ToList();

            if (checkForRoom == null)
            {
                DbRoom newRoom = new DbRoom(room);
                newRoom.Accessories = accessoryCheck;
                
                _context.Rooms.Add(newRoom);
                await _context.SaveChangesAsync();
                return CreatedAtAction("CreateRoom", room);
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
                return Ok();
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
    }
}