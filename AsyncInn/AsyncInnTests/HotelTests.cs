using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore.Storage;

namespace AsyncInnTests
{
    public class HotelTests : DBTestBase
    {
        private IHotel BuildHotelRepo()
        {
            return new HotelRepo(_db, _hotelRoom);
        }

        private IHotelRoom BuildHotelRoomRepo()
        {
            return new HotelRoomRepo(_db, _room);
        }

        [Fact]
        public async Task CanCreateAndReturnHotelDTO()
        {
            // arrange
            var hotel = new Hotel
            {
                Name = "Mariott",
                City = "Seattle",
                StreetAddress = "Main Street",
                State = "WA",
                Phone = "8675309"
            };

            var repo = BuildHotelRepo();

            HotelDTO hotelDTO = new HotelDTO()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };
            // act

            var savedHotel = await repo.Create(hotelDTO);

            // assert
            Assert.NotNull(savedHotel);
            Assert.Equal(savedHotel.Id, hotel.Id);
            Assert.Equal(hotel.Name, savedHotel.Name);
        }

        // TODO: not working
        [Fact]
        public async Task CanCreateAndReturnHotelRoomDTO()
        {
            // arrange
            var hotel = new Hotel
            {
                Id = 1,
                Name = "Mariott",
                City = "Seattle",
                StreetAddress = "Main Street",
                State = "WA",
                Phone = "8675309"
            };

            HotelDTO hotelDTO = new HotelDTO()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };

            var hotelRoom = new HotelRoom
            {
                RoomId = 1,
                RoomNumber = 1,
                Rate = 100.00M,
                PetFriendly = true
            };

            HotelRoomDTO hotelRoomDTO = new HotelRoomDTO()
            {
                HotelId = hotelRoom.HotelId,
                RoomId = hotelRoom.RoomId,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly
            };

            var hotelRepo = BuildHotelRepo();
            var hotelRoomRepo = BuildHotelRoomRepo();
            // act
            var savedHotel = await hotelRepo.Create(hotelDTO);
            var savedHotelRoom = await hotelRoomRepo.Create(hotelRoomDTO, savedHotel.Id);

            // assert
            Assert.NotNull(savedHotelRoom);
            Assert.Equal(savedHotelRoom.HotelId, hotelRoom.HotelId);
            Assert.Equal(hotelRoom.Rate, savedHotelRoom.Rate);
            Assert.True(savedHotelRoom.PetFriendly);
        }
    }
}