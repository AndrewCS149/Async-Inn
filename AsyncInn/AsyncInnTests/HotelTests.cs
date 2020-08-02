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
        private IHotel BuildRepository()
        {
            return new HotelRepo(_db, _hotelRoom);
        }

        [Fact]
        public async Task CanCreateAndReturnDTO()
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

            var repo = BuildRepository();

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
    }
}