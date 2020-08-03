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
    public class HotelRoomTests : DBTestBase
    {
        private IHotelRoom BuildRepository()
        {
            return new HotelRoomRepo(_db, _room);
        }

        //[Fact]
        //public async Task CanCreateAndReturnDTO()
        //{
        //    // arrange
        //    var hotelRoom = new HotelRoom
        //    {
        //        RoomId = 1,
        //        RoomNumber = 1,
        //        Rate = 100.00M,
        //        PetFriendly = true
        //    };

        //    var repo = BuildRepository();

        //    HotelRoomDTO hotelRoomDTO = new HotelRoomDTO()
        //    {
        //        HotelId = hotelRoom.HotelId,
        //        RoomId = hotelRoom.RoomId,
        //        RoomNumber = hotelRoom.RoomNumber,
        //        Rate = hotelRoom.Rate,
        //        PetFriendly = hotelRoom.PetFriendly
        //    };

        //    // act

        //    var savedHotelRoom = await repo.Create(hotelRoomDTO, hotelRoom.HotelId);

        //    // assert
        //    Assert.NotNull(savedHotelRoom);
        //    Assert.Equal(savedHotelRoom.HotelId, hotelRoom.HotelId);
        //    Assert.Equal(hotelRoom.Rate, savedHotelRoom.Rate);
        //    Assert.True(savedHotelRoom.PetFriendly);
        //}
    }
}