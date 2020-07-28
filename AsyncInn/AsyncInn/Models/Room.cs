using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Room Type Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Layout Type:")]
        [EnumDataType(typeof(Layout))]
        public int Layout { get; set; }

        // nav props
        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        TwoBedSuite = 1,
        OneBedSuite,
        Studio
    }
}
