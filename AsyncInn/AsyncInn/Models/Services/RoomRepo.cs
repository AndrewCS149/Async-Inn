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

        /// <summary>
        /// Constructor for RoomRepo
        /// </summary>
        /// <param name="context">Database context<</param>
        public RoomRepo(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a room
        /// </summary>
        /// <param name="room">The room to create</param>
        /// <returns>Task of completion</returns>
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return room;
        }

        /// <summary>
        /// Deletes a specified room
        /// </summary>
        /// <param name="id">Unique identifier of room</param>
        /// <returns>Task of completion/returns>
        public async Task Delete(int id)
        {
            Room room= await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns all rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<Room>> GetAllRooms()
        {
            var rooms = await _context.Room.Include(x => x.RoomAmenities).ThenInclude(x => x.Amenity).ToListAsync();
            return rooms;
        }

        /// <summary>
        /// Returns a specified room
        /// </summary>
        /// <param name="id">Unique identifier of room</param>
        /// <returns>Task of completion</returns>
        public async Task<Room> GetRoom(int id)
        {
            Room room = await _context.Room.FindAsync(id);

            // include all of the amenities that the room has
            var amenity = await _context.RoomAmenity.Where(x => x.RoomId == id)
                .Include(x => x.Amenity)
                .ToListAsync();

            room.RoomAmenities = amenity;
            return room;
        }

        /// <summary>
        /// Updates a room
        /// </summary>
        /// <param name="room">The room to update</param>
        /// <returns>Task of completion</returns>
        public async Task<Room> Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        /// <summary>
        /// Adds an amenity and room together
        /// </summary>
        /// <param name="roomId">Unique identifier of room</param>
        /// <param name="amenityId">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                RoomId = roomId,
                AmenitiesId = amenityId
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a specified amenity from a specific room
        /// </summary>
        /// <param name="roomId">Unique identifier of room</param>
        /// <param name="amenityId">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var result = await _context.RoomAmenity.FirstOrDefaultAsync(x => x.RoomId == roomId && x.AmenitiesId == amenityId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
