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

        /// <summary>
        /// Creates an amenity
        /// </summary>
        /// <param name="amenity">The amenity to create</param>
        /// <returns>Task of completion</returns>
        public async Task<Amenities> Create(Amenities amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return amenity;
        }

        /// <summary>
        /// Returns all amenities
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<Amenities>> GetAllAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        /// <summary>
        /// Returns a specified amenity
        /// </summary>
        /// <param name="id">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        public async Task<Amenities> GetAmenity(int id)
        {
            Amenities amenity = await _context.Amenities.FindAsync(id);
            var roomAmenities = await _context.RoomAmenity.Where(x => x.AmenitiesId == id)
                .Include(x => x.Room)
                .ToListAsync();

            amenity.RoomAmenities = roomAmenities;
            return amenity;
        }

        /// <summary>
        /// Updates an amenity
        /// </summary>
        /// <param name="amenity">The amenity to update</param>
        /// <returns>Task of completion</returns>
        public async Task<Amenities> Update(Amenities amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }

        /// <summary>
        /// Deletes an amenity
        /// </summary>
        /// <param name="id">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Amenities amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
