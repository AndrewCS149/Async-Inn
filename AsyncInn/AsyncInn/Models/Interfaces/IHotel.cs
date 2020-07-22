using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IHotel
    {
        // contain methods and properties that are required for the classes to implement 

        // create
        Hotel Create(Hotel hotel);

        // read
        // get all
        List<Hotel> GetAllHotels();

        // get individually (by id)
        Hotel GetHotel(int id);

        // update
        Hotel Update(int id, Hotel hotel);

        // delete
        void Delete(int id);
    }
}
