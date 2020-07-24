using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        // create
        Task<Room> Create(Room room);

        // read
        // get all
        Task<List<Room>> GetAllRooms();

        // get individually (by id)
        Task<Room> GetRoom(int id);

        // update
        Task<Room> Update(Room room);

        // delete
        Task Delete(int id);

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
