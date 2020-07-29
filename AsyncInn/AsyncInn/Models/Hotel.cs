using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress{ get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }

        // Navigation Properties
        public ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
