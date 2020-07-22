using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        // contain methods and properties that are required for the classes to implement 

        // create
        Task<Hotel> Create(Hotel hotel);

        // read
        // get all
        Task<List<Hotel>> GetAllHotels();

        // get individually (by id)
        Task<Hotel> GetHotel(int id);

        // update
        Task<Hotel> Update(Hotel hotel);

        // delete
        Task Delete(int id);
    }
}
