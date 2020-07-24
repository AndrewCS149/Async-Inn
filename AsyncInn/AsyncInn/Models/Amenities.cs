using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // nav prop
        public List<RoomAmenities> RoomAmenities { get; set; }
    }
}
