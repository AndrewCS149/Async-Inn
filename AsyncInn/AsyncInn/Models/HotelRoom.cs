using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        [Required]
        [Display(Name = "Name of Hotel:")]
        public int HotelId { get; set; }

        [Required]
        [Display(Name = "Room Type:")]
        public int RoomId { get; set; }

        [Required]
        [Display(Name = "Room Number:")]
        public int RoomNumber { get; set; }

        [Required]
        [Display(Name = "Daily Rate:")]
        public decimal Rate { get; set; }

        [Required]
        [Display(Name = "Pet Friendly?")]
        public bool PetFriendly { get; set; }

        // nav props
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}
