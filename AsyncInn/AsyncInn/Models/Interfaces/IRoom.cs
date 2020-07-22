using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IRoom
    {
        // create
        Task<Room> Create(Room room);

        // read
        // get all
        Task<List<Room>> GetAllRooms();

        // get individually (by id)
        Task<Room> GetRoom(int id);

        // update
        Room Update(int id, Room room);

        // delete
        Task Delete(int id);
    }
}
