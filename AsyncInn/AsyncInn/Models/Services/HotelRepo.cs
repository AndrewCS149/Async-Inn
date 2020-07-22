using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelRepo : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public Hotel Create(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotels()
        {
            throw new NotImplementedException();
        }

        public Hotel GetHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Hotel Update(int id, Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
