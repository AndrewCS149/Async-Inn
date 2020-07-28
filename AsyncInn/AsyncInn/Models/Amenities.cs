using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [Display(Name = "Amenity Name:")]
        public string Name { get; set; }

        // nav prop
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
