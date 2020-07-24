using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        /// <summary>
        /// Creates a hotel
        /// </summary>
        /// <param name="hotel">The hotel to create</param>
        /// <returns>Task of completion</returns>
        Task<Hotel> Create(Hotel hotel);

        /// <summary>
        /// Returns all hotels
        /// </summary>
        /// <returns>Task of completion</returns>
        Task<List<Hotel>> GetAllHotels();

        /// <summary>
        /// Returns a specified hotel
        /// </summary>
        /// <param name="id">Unique identifier of hotel</param>
        /// <returns>Task of completion</returns>
        Task<Hotel> GetHotel(int id);

        /// <summary>
        /// Updates a hotel
        /// </summary>
        /// <param name="hotel">The hotel to update</param>
        /// <returns>Task of completion</returns>
        Task<Hotel> Update(Hotel hotel);

        /// <summary>
        /// Deletes a hotel
        /// </summary>
        /// <param name="id">Unique identifier of hotel</param>
        /// <returns>Task of completion</returns>
        Task Delete(int id);
    }
}
