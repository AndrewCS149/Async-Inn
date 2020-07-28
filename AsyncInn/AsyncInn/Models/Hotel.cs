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

        [Required]
        [Display(Name = "Hotel Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Street Address:")]
        public string StreetAddress{ get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Phone Number:")]
        public string Phone { get; set; }

        // Navigation Properties coming soon
        public ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
