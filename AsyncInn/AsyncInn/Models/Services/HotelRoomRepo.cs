using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepo : IHotelRoom
    {
        public Task AddRoomToHotel(int roomId, int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<HotelRoom>> GetAllHotelRooms()
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetHotelRoom(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRoomFromHotel(int roomId, int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> Update(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
}
