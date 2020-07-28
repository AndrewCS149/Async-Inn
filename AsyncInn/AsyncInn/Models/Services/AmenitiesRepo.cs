using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Services
{
    public class AmenitiesRepo : IAmenities
    {
        private AsyncInnDbContext _context;

        /// <summary>
        /// Constructor for AmenitiesRepo
        /// </summary>
        /// <param name="context">Database context</param>
        public AmenitiesRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates an amenity
        /// </summary>
        /// <param name="amenity">The amenity to create</param>
        /// <returns>Task of completion</returns>
        public async Task<AmenityDTO> Create(AmenityDTO amenity)
        {

            Amenities entity = new Amenities()
            {
                Name = amenity.Name
            };

            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        /// <summary>
        /// Returns all amenities
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<AmenityDTO>> GetAllAmenities()
        {
            var list = await _context.Amenities.ToListAsync();
            var amenities = new List<AmenityDTO>();

            foreach (var item in list)
                amenities.Add(await GetAmenity(item.Id));

            return amenities;
        }

        /// <summary>
        /// Returns a specified amenity
        /// </summary>
        /// <param name="id">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        public async Task<AmenityDTO> GetAmenity(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            //var amenity = await _context.Amenities.Select(a =>
            //    new AmenityDTO()
            //    {
            //        Id = a.Id,
            //        Name = a.Name
            //    }).SingleOrDefaultAsync(a => a.Id == id);

            AmenityDTO dto = new AmenityDTO()
            {
                Id = amenity.Id,
                Name = amenity.Name
            };

            return dto;
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
            var amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
