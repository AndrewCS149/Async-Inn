using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [Required]
        [Display(Name = "Amenity Name:")]
        public int AmenitiesId { get; set; }

        [Required]
        [Display(Name = "Room Type:")]
        public int RoomId { get; set; }

        // navigation properties
        public Room Room { get; set; }
        public Amenities Amenity { get; set; }
    }
}
