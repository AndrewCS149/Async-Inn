using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenity { get; set; }
        //public DbSet<HotelRoom> HotelRoom { get; set; }

        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<HotelRoom>().HasKey(x => new { x.HotelId, x.RoomNumber });

            modelBuiler.Entity<RoomAmenities>().HasKey(x => new { x.RoomId, x.AmenitiesId});


            modelBuiler.Entity<Hotel>().HasData(
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
            modelBuiler.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "Relax",
                    Layout = 2
                },
                new Room
                {
                    Id = 2,
                    Name = "Vibrant",
                    Layout = 1
                },
                new Room
                {
                    Id = 3,
                    Name = "Sooth",
                    Layout = 0
                }
            );
            modelBuiler.Entity<Amenities>().HasData(
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

        public DbSet<AsyncInn.Models.HotelRoom> HotelRoom { get; set; }
    }
}
