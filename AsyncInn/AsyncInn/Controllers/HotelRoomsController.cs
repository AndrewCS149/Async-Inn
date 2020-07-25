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

namespace AsyncInn.Controllers
{
    [Route("api/{Hotels}")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/Hotels/Rooms
        [HttpGet]
        [Route("Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetAllHotelRooms()
        {
            return await _hotelRoom.GetAllHotelRooms();
        }

        // GET: api/Hotels/1/Rooms
        [HttpGet]
        [Route("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetAllRoomsAtHotel(int hotelId)
        {
            return await _hotelRoom.GetAllRoomsAtHotel(hotelId);
        }


        // GET: api/HotelRooms/5
        [HttpGet("{id}")]
        [Route("{hotelId}/Rooms/{roomId}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int roomNum, int hotelId)
        {
            return await _hotelRoom.GetHotelRoom(roomNum, hotelId);
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelId)
            {
                return BadRequest();
            }

            var updatedHotelRoom = await _hotelRoom.Update(hotelRoom);
            return Ok(updatedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int roomNum, int hotelId)
        {
            await _hotelRoom.AddRoomToHotel(roomNum, hotelId);
            return Ok();
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int roomNum, int hotelId)
        {
            await _hotelRoom.RemoveRoomFromHotel(roomNum, hotelId);
            return Ok();
        }
    }
}
