﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        /// <summary>
        /// Creates a hotel room
        /// </summary>
        /// <param name="hotelRoom">The hotel room to create</param>
        /// <returns>Task of completion</returns>
        Task<HotelRoom> Create(HotelRoom hotelRoom);

        /// <summary>
        /// Returns all hotel rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        Task<List<HotelRoom>> GetAllHotelRooms();

        /// <summary>
        /// Returns all rooms at a specified hotel
        /// </summary>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        Task<List<HotelRoom>> GetAllRoomsAtHotel(int hotelId);

        /// <summary>
        /// Returns a specified hotel room
        /// </summary>
        /// <param name="roomId">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        Task<HotelRoom> GetHotelRoom(int roomNum, int hotelId);

        /// <summary>
        /// Updates a hotel room
        /// </summary>
        /// <param name="hotelRoom">The hotel room to update</param>
        /// <returns>Task of completion</returns>
        Task<HotelRoom> Update(HotelRoom hotelRoom);

        /// <summary>
        /// Adds a room to a hotel
        /// </summary>
        /// <param name="roomId">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        Task AddRoomToHotel(int roomNum, int hotelId);

        /// <summary>
        /// Deletes a specified hotel room
        /// </summary>
        /// <param name="id">Unique identifier of room</param>
        /// <param name="id">Unique identifier of hotel</param>
        /// <returns>Task of completion</returns>
        Task Delete(int roomNum, int hotelId);

        /// <summary>
        /// Removes a room from a hotel
        /// </summary>
        /// <param name="roomId">Unique identifier of a room</param>
        /// <param name="hotelId">Unique identifier of a hotel</param>
        /// <returns>Task of completion</returns>
        Task RemoveRoomFromHotel(int roomNum, int hotelId);
    }
}
