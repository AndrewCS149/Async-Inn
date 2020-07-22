using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomRepo : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public Room Create(Room room)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public Room GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public Room Update(int id, Room room)
        {
            throw new NotImplementedException();
        }
    }
}
