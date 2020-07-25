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
        /// <param name="roomNum">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoom> GetHotelRoom(int roomNum, int hotelId)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(roomNum, hotelId);
            return hotelRoom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<List<HotelRoom>> GetAllRoomsAtHotel(int hotelId)
        {
            var hotelRooms = await _context.HotelRoom.Where(x => x.HotelId == hotelId).Include(x => x.Hotel).ToListAsync();
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
            HotelRoom hotelRoom = await GetHotelRoom(roomNum, hotelId);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a room from a hotel
        /// </summary>
        /// <param name="roomNum">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        public async Task RemoveRoomFromHotel(int roomNum, int hotelId)
        {
            var result = await _context.HotelRoom.FirstOrDefaultAsync(x => x.HotelId == hotelId && x.RoomId == roomNum);
            await _context.SaveChangesAsync();
        }

    }
}
