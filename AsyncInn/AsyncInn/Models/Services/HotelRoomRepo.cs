using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepo : IHotelRoom
    {
        private AsyncInnDbContext _context;

        /// <summary>
        /// Constructor for HotelRoomRepo
        /// </summary>
        /// <param name="context">Database context</param>
        public HotelRoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a hotel room
        /// </summary>
        /// <param name="hotelRoom">The hotel room to create</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        /// <summary>
        /// Returns all hotel rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<HotelRoom>> GetAllHotelRooms()
        {
            var hotelRooms = await _context.HotelRoom.ToListAsync();
            return hotelRooms;
        }

        /// <summary>
        /// Returns a specified hotel room
        /// </summary>
        /// <param name="id">Unique identifier of hotel room</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoom> GetHotelRoom(int id)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(id);
            return hotelRoom;
        }

        /// <summary>
        /// Updates a hotel room
        /// </summary>
        /// <param name="hotelRoom">The hotel room to update</param>
        /// <returns>Task of completion</returns>
        public Task<HotelRoom> Update(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a room to a hotel
        /// </summary>
        /// <param name="roomId">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public Task AddRoomToHotel(int roomId, int hotelId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a specified hotel room
        /// </summary>
        /// <param name="id">Unique identifier of hotel room</param>
        /// <returns>Task of completion</returns>
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a room from a hotel
        /// </summary>
        /// <param name="roomId">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public Task RemoveRoomFromHotel(int roomId, int hotelId)
        {
            throw new NotImplementedException();
        }

    }
}
