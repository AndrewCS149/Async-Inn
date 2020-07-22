using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IAmenities
    {
        // create
        Amenities Create(Amenities amenity);

        // read
        // get all
        List<Amenities> GetAllAmenities();

        // get individually (by id)
        Amenities GetAmenity(int id);

        // update
        Amenities Update(int id, Amenities amenity);

        // delete
        void Delete(int id);
    }
}
