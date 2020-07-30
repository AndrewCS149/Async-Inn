using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Services
{
    public class HotelRepo : IHotel
    {
        private AsyncInnDbContext _context;

        /// <summary>
        /// Constructor for HotelRepo
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="hotel">IHotel reference</param>
        public HotelRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a hotel
        /// </summary>
        /// <param name="hotel">The hotel to create</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelDTO> Create(HotelDTO hotel)
        {
            Hotel entity = new Hotel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };

            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotel;
        }

        /// <summary>
        /// Returns all hotels
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<HotelDTO>> GetAllHotels()
        {
            var list = await _context.Hotels.ToListAsync();
            var hotels = new List<HotelDTO>();

            foreach (var hotel in list)
            {
                hotels.Add(await GetHotel(hotel.Id));
            }

            return hotels;
        }

        /// <summary>
        /// Returns a specified hotel
        /// </summary>
        /// <param name="id">Unique identifier of hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelDTO> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);

            HotelDTO dto = new HotelDTO()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };

            return dto;
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
            var result = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}