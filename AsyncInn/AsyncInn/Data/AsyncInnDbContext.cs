using AsyncInn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenity { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }

        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // need to get the original behavior for our model override
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelId, x.RoomNumber });

            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.RoomId, x.AmenitiesId });

            // seed hotelRoom data
            modelBuilder.Entity<HotelRoom>().HasData(
                new HotelRoom
                {
                    HotelId = 1,
                    RoomId = 1,
                    RoomNumber = 1,
                    Rate = 75.00M,
                    PetFriendly = true
                },

                new HotelRoom
                {
                    HotelId = 1,
                    RoomId = 2,
                    RoomNumber = 2,
                    Rate = 125.00M,
                    PetFriendly = false
                },

                new HotelRoom
                {
                    HotelId = 1,
                    RoomId = 3,
                    RoomNumber = 3,
                    Rate = 100.00M,
                    PetFriendly = true
                }
            );

            // seed hotel data
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Good Feels Inn",
                    StreetAddress = "12345 Road Street",
                    City = "Seattle",
                    State = "WA",
                    Phone = "8675309"
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Nice Stay Lounge",
                    StreetAddress = "334 2nd street",
                    City = "Rockford",
                    State = "IL",
                    Phone = "8675309"
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Relaxation Paradise",
                    StreetAddress = "61107 Hillbridge Road",
                    City = "Issaquah",
                    State = "WA",
                    Phone = "8675309"
                }
            );

            // seed room data
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "Relax",
                    Layout = Layout.OneBedSuite
                },
                new Room
                {
                    Id = 2,
                    Name = "Vibrant",
                    Layout = Layout.Studio
                },
                new Room
                {
                    Id = 3,
                    Name = "Sooth",
                    Layout = Layout.TwoBedSuite
                }
            );

            // seed amenities data
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    Id = 1,
                    Name = "Fridge"
                },
                new Amenities
                {
                    Id = 2,
                    Name = "Microwave"
                },
                new Amenities
                {
                    Id = 3,
                    Name = "Minibar"
                }
            );
        }
    }
}
