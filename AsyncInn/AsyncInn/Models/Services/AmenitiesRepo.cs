using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenitiesRepo : IAmenities
    {
        private AsyncInnDbContext _context;

        public AmenitiesRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Amenities> Create(Amenities amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenities amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenities>> GetAllAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenities> GetAmenity(int id)
        {
            Amenities amenity = await _context.Amenities.FindAsync(id);
            var roomAmenities = await _context.RoomAmenity.Where(x => x.AmenitiesId == id)
                .Include(x => x.Room)
                .ToListAsync();

            amenity.RoomAmenities = roomAmenities;
            return amenity;
        }

        public async Task<Amenities> Update(Amenities amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
