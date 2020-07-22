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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Amenities> GetAllAmenities()
        {
            throw new NotImplementedException();
        }

        public async Task<Amenities> GetAmenity(int id)
        {
            Amenities amenity = await _context.Amenities.FindAsync(id);
            return amenity;
        }

        public Amenities Update(int id, Amenities amenity)
        {
            throw new NotImplementedException();
        }
    }
}
