using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public Layout LayoutType { get; set; }

        // Navigation properties
        //public ICollection<RoomAmenities> RoomAmenities { get; set; }
        public List<AmenityDTO> RoomAmenities { get; set; }
    }
}
