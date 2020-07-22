using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenitiesRepo : IAmenities
    {
        private AsyncInnDbContext _context;

        public AmenitiesRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public Amenities Create(Amenities amenity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Amenities> GetAllAmenities()
        {
            throw new NotImplementedException();
        }

        public Amenities GetAmenity(int id)
        {
            throw new NotImplementedException();
        }

        public Amenities Update(int id, Amenities amenity)
        {
            throw new NotImplementedException();
        }
    }
}
