using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Models.Services
{
    public class RoomRepo : IRoom
    {
        private AsyncInnDbContext _context;
        private IAmenities _amenities;

        /// <summary>
        /// Constructor for RoomRepo
        /// </summary>
        /// <param name="context">Database context<</param>
        /// <param name="amenities">IAmenities reference</param>
        public RoomRepo(AsyncInnDbContext context, IAmenities amenities)
        {
            _amenities = amenities;
            _context = context;
        }

        /// <summary>
        /// Creates a room
        /// </summary>
        /// <param name="room">The room to create</param>
        /// <returns>Task of completion</returns>
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            Room entity = new Room()
            {
                Name = room.RoomType,
                Layout = room.LayoutType
            };


            _context.Entry(entity).State = EntityState.Added;
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
            var room= await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns all rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<RoomDTO>> GetAllRooms()
        {
            var list = await _context.Room.ToListAsync();
            var rooms = new List<RoomDTO>();

            foreach (var room in list)
                rooms.Add(await GetRoom(room.Id));

            return rooms;
        }

        /// <summary>
        /// Returns a specified room
        /// </summary>
        /// <param name="id">Unique identifier of room</param>
        /// <returns>Task of completion</returns>
        public async Task<RoomDTO> GetRoom(int id)
        {
            Room room = await _context.Room.FindAsync(id);

            RoomDTO dto = new RoomDTO()
            {
                Id = room.Id,
                RoomType = room.Name,
                LayoutType = room.Layout
            };

            return dto;
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
