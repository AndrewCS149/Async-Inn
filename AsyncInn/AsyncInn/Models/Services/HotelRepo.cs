using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelRepo : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            // when I have a hotel, I want to add it to the DB
            _context.Entry(hotel).State = EntityState.Added;

            // hotel gets 'saved' here, and then given an id
            await _context.SaveChangesAsync();

            return hotel;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotels()
        {
            throw new NotImplementedException();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        public Hotel Update(int id, Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
