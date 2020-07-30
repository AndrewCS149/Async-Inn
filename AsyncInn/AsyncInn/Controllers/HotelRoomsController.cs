﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/{Hotels}")]
    [Authorize]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // gets all hotel rooms in the entire database
        // GET: api/Hotels/Rooms
        [HttpGet]
        [Route("Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetAllHotelRooms()
        {
            return await _hotelRoom.GetAllHotelRooms();
        }

        // gets all details of a specified hotel room
        // GET: api/Hotels/1/Rooms/2/Details
        [HttpGet]
        [Route("{hotelId}/Rooms/{roomNum}/Details")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoomDetails(int hotelId, int roomNum)
        {
            return await _hotelRoom.GetHotelRoomDetails(hotelId, roomNum);
        }

        // gets all the rooms at a specified hotel
        // GET: api/Hotels/1/Rooms
        [AllowAnonymous]
        [HttpGet]
        [Route("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetAllRoomsAtHotel(int hotelId)
        {
            return await _hotelRoom.GetAllRoomsAtHotel(hotelId);
        }

        // gets a specified room at a specified hotel
        // GET: api/HotelRooms/5
        [HttpGet("{id}")]
        [Route("{hotelId}/Rooms/{roomNum}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int roomNum, int hotelId)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(roomNum, hotelId);

            if (hotelRoom == null)
                return NotFound();

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Route("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelId || roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            await _hotelRoom.Update(hotelRoom);
            return NoContent();
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom, int hotelId)
        {
            await _hotelRoom.Create(hotelRoom, hotelId);
            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelId }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete]
        [Route("{hotelId}/Rooms/{roomNum}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int roomNum, int hotelId)
        {
            await _hotelRoom.Delete(roomNum, hotelId);
            return NoContent();
        }
    }
}
