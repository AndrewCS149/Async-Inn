using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IAmenities
    {
        // create
        Task<Amenities> Create(Amenities amenity);

        // read
        // get all
        Task<List<Amenities>> GetAllAmenities();

        // get individually (by id)
        Task<Amenities> GetAmenity(int id);

        // update
        Amenities Update(int id, Amenities amenity);

        // delete
        Task Delete(int id);
    }
}
