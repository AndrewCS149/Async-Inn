using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AsyncInn.Models.Services
{
    public class RoomRepo : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return room;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public async Task<Room> GetRoom(int id)
        {
            Room room = await _context.Room.FindAsync(id);
            return room;
        }

        public Room Update(int id, Room room)
        {
            throw new NotImplementedException();
        }
    }
}
