using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AsyncInn.Models.Services
{
    public class HotelRepo : IHotel
    {
        private AsyncInnDbContext _context;

        /// <summary>
        /// Constructor for HotelRepo
        /// </summary>
        /// <param name="context">Database context</param>
        public HotelRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a hotel
        /// </summary>
        /// <param name="hotel">The hotel to create</param>
        /// <returns>Task of completion</returns>
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotel;
        }

        /// <summary>
        /// Returns all hotels
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<Hotel>> GetAllHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        // TODO: not grabbing all the hotel info on route
        /// <summary>
        /// Returns a specified hotel
        /// </summary>
        /// <param name="id">Unique identifier of hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.Where(x => x.Id == id)
                                               .Include(x => x.HotelRoom)
                                               .ThenInclude(x => x.Room)
                                               .ThenInclude(x => x.RoomAmenities)
                                               .ThenInclude(x => x.Amenity)
                                               .FirstOrDefaultAsync();
            return hotel;
        }

        /// <summary>
        /// Updates a hotel
        /// </summary>
        /// <param name="hotel">The hotel to update</param>
        /// <returns>Task of completion</returns>
        public async Task<Hotel> Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        /// <summary>
        /// Deletes a hotel
        /// </summary>
        /// <param name="id">Unique identifier of hotel</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
