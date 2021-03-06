﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }

        // Navigation properties
        public List<AmenityDTO> RoomAmenities { get; set; }
    }
}