using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTOs
{
    public class HotelRoomDTO
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public decimal DailyRate { get; set; }
        public bool PetFriendly { get; set; }

        // Navigation properties
        public RoomDTO Room { get; set; }
    }
}