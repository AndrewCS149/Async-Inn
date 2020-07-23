﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenitiesId { get; set; }
        public int RoomId { get; set; }

        // navigation properties
        public Room room { get; set; }
        public Amenities Amenity { get; set; }
    }
}
