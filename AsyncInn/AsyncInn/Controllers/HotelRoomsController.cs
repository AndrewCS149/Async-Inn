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
    [Route("api/Hotels")]
    [ApiController]
    [Authorize]
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
        [Authorize(Policy = "TierOne")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetAllHotelRooms()
        {
            return await _hotelRoom.GetAllHotelRooms();
        }

        // gets all details of a specified hotel room
        // GET: api/Hotels/1/Rooms/2
        [HttpGet]
        [Route("{hotelId}/Rooms/{roomNum}")]
        [Authorize(Policy = "TierThree")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelId, int roomNum)
        {
            return await _hotelRoom.GetHotelRoom(hotelId, roomNum);
        }

        // gets all the rooms at a specified hotel
        // GET: api/Hotels/1/Rooms
        [HttpGet]
        [Route("{hotelId}/Rooms")]
        [Authorize(Policy = "TierThree")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetAllRoomsAtHotel(int hotelId)
        {
            return await _hotelRoom.GetAllRoomsAtHotel(hotelId);
        }

        // PUT: api/HotelRooms/5
        [HttpPut]
        [Route("{hotelId}/Rooms/{roomNumber}")]
        [Authorize(Policy = "TierThree")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelId || roomNumber != hotelRoom.RoomNumber)
                return BadRequest();

            await _hotelRoom.Update(hotelRoom);
            return NoContent();
        }

        // POST: api/Hotels/1
        [HttpPost]
        [Route("{hotelId}")]
        [Authorize(Policy = "TierTwo")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom, int hotelId)
        {
            if (hotelId != hotelRoom.HotelId)
                return BadRequest();

            await _hotelRoom.Create(hotelRoom, hotelId);
            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelId }, hotelRoom);
        }

        // DELETE: api/Hotels/5
        [HttpDelete]
        [Route("{hotelId}/Rooms/{roomNum}")]
        [Authorize(Policy = "TierTwo")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int roomNum, int hotelId)
        {
            await _hotelRoom.Delete(roomNum, hotelId);
            return NoContent();
        }
    }
}