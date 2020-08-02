using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using System.Runtime.InteropServices.WindowsRuntime;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsController : ControllerBase
    {
        private AsyncInnDbContext _context;
        private readonly IRoom _room;

        public RoomsController(IRoom room, AsyncInnDbContext context)
        {
            _context = context;
            _room = room;
        }

        // Gets all room types
        // GET: api/Rooms
        [HttpGet]
        [Authorize(Policy = "TierThree")]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetAllRooms()
        {
            return await _room.GetAllRooms();
        }

        // gets a specified room type
        // GET: api/Rooms/5
        [HttpGet("{id}")]
        [Authorize(Policy = "TierThree")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _room.GetRoom(id);

            if (room == null)
                return NotFound();

            return room;
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        [Authorize(Policy = "TierTwo")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
                return BadRequest();

            await _room.Update(room);

            return NoContent();
        }

        // POST: api/Rooms
        [HttpPost]
        [Authorize(Policy = "TierTwo")]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // POST: {roomId}/Amenity/{amenityId}
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        [Authorize(Policy = "TierThree")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return Ok();
        }

        // DELETE
        [HttpDelete]
        [Route("{roomId}/Amenity/{amenityId}")]
        [Authorize(Policy = "TierThree")]
        public async Task<ActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmenityFromRoom(roomId, amenityId);
            return Ok();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "TierTwo")]
        public async Task DeleteRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}