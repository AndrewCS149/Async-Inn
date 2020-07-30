using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTests
{
    public class UnitTest1 : DBTestBase
    {
        private IHotel BuildRepo()
        {
            return new HotelRepo(_db);
        }


        [Fact]
        public async Task CanSaveAndGet()
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

            var repo = BuildRepo();

            // act
            // TODO: convert to DTO
            var savedHotel = await repo.Create(hotel);

            // assert
            Assert.NotNull(savedHotel);
            Assert.NotEqual(0, hotel.Id);
            Assert.Equal(savedHotel.Id, hotel.Id);
            Assert.Equal(hotel.Name, savedHotel.Name);
        }
    }
}
