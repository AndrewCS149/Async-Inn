using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        /// <summary>
        /// Creates a room
        /// </summary>
        /// <param name="room">The room to create</param>
        /// <returns>Task of completion</returns>
        Task<RoomDTO> Create(RoomDTO room);

        /// <summary>
        /// Returns all rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        Task<List<RoomDTO>> GetAllRooms();

        /// <summary>
        /// Returns a specified room
        /// </summary>
        /// <param name="id">Unique identifier of room</param>
        /// <returns>Task of completion</returns>
        Task<RoomDTO> GetRoom(int id);

        /// <summary>
        /// Updates a room
        /// </summary>
        /// <param name="room">The room to update</param>
        /// <returns>Task of completion</returns>
        Task<Room> Update(Room room);

        /// <summary>
        /// Deletes a specified room
        /// </summary>
        /// <param name="id">Unique identifier of room</param>
        /// <returns>Task of completion/returns>
        Task Delete(int id);

        /// <summary>
        /// Adds an amenity to a room
        /// </summary>
        /// <param name="roomId">Unique identifier of room</param>
        /// <param name="amenityId">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        Task AddAmenityToRoom(int roomId, int amenityId);

        /// <summary>
        /// Removes a specified amenity from a specific room
        /// </summary>
        /// <param name="roomId">Unique identifier of room</param>
        /// <param name="amenityId">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        Task RemoveAmenityFromRoom(int roomId, int amenityId);
    }
}
