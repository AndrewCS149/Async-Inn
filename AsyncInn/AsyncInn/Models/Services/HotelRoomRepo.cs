using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using AsyncInn.Models.DTOs;
using AsyncInn.Migrations;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepo : IHotelRoom
    {
        private AsyncInnDbContext _context;
        private IRoom _room;

        /// <summary>
        /// Constructor for HotelRoomRepo
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="hotelRoom">IHotelRoom reference</param>
        public HotelRoomRepo(AsyncInnDbContext context, IRoom room)
        {
            _context = context;
            _room = room;
        }

        /// <summary>
        /// Creates a hotel room
        /// </summary>
        /// <param name="hotelRoom">The hotel room to create</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoom, int hotelId)
        {
            HotelRoom entity = new HotelRoom()
            {
                HotelId = hotelRoom.HotelId,
                RoomId = hotelRoom.RoomId,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.DailyRate,
                PetFriendly = hotelRoom.PetFriendly
            };

            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        /// <summary>
        /// Returns all hotel rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<HotelRoomDTO>> GetAllHotelRooms()
        {
            var list = await _context.HotelRoom.ToListAsync();
            var hotelRooms = new List<HotelRoomDTO>();

            foreach (var hotelRoom in list)
                hotelRooms.Add(await GetHotelRoom(hotelRoom.HotelId, hotelRoom.RoomNumber));

            return hotelRooms;
        }

        /// <summary>
        /// Retrieves the hotel room details of a specified room
        /// </summary>
        /// <param name="roomNum">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoomDTO> GetHotelRoomDetails(int hotelId, int roomNum)
        {
            var hotelRoom = await _context.HotelRoom.Where(h => h.HotelId == hotelId && h.RoomNumber == roomNum)
                                                    .FirstOrDefaultAsync();

            var roomDTO = await _room.GetRoom(hotelRoom.RoomId);

            HotelRoomDTO dto = new HotelRoomDTO()
            {
                HotelId = hotelRoom.HotelId,
                RoomId = hotelRoom.RoomId,
                RoomNumber = hotelRoom.RoomNumber,
                DailyRate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                Room = roomDTO
            };

            return dto;
        }

        // TODO: delete
        /// <summary>
        /// Returns a specified hotel room
        /// </summary>
        /// <param name="roomNum">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoomDTO> GetHotelRoom(int roomNum, int hotelId)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(roomNum, hotelId);

            HotelRoomDTO dto = new HotelRoomDTO()
            {
                HotelId = hotelRoom.HotelId,
                RoomId = hotelRoom.RoomId,
                RoomNumber = hotelRoom.RoomNumber,
                DailyRate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly
            };

            return dto;
        }

        /// <summary>
        /// Returns all rooms at a specified hotel
        /// </summary>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<List<HotelRoomDTO>> GetAllRoomsAtHotel(int hotelId)
        {
            var list = await _context.HotelRoom.ToListAsync();
            var hotelRooms = new List<HotelRoomDTO>();

            foreach (var room in list)
                hotelRooms.Add(await GetHotelRoom(hotelId, room.RoomNumber));

            return hotelRooms;
        }

        /// <summary>
        /// Updates a hotel room
        /// </summary>
        /// <param name="hotelRoom">The hotel room to update</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoom> Update(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        /// <summary>
        /// Adds a room to a hotel
        /// </summary>
        /// <param name="roomNum">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public async Task AddRoomToHotel(int roomNum, int hotelId)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                RoomId = roomNum,
                HotelId = hotelId
            };
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a specified hotel room
        /// </summary>
        /// <param name="roomNum">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int roomNum, int hotelId)
        {
            var hotelRoom = await GetHotelRoom(roomNum, hotelId);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}