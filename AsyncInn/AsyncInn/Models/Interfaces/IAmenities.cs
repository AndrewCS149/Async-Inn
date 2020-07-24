using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenities
    {
        /// <summary>
        /// Creates an amenity
        /// </summary>
        /// <param name="amenity">The amenity to create</param>
        /// <returns>Task of completion</returns>
        Task<Amenities> Create(Amenities amenity);

        /// <summary>
        /// Returns all amenities
        /// </summary>
        /// <returns>Task of completion</returns>
        Task<List<Amenities>> GetAllAmenities();

        /// <summary>
        /// Returns a specified amenity
        /// </summary>
        /// <param name="id">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        Task<Amenities> GetAmenity(int id);

        /// <summary>
        /// Updates an amenity
        /// </summary>
        /// <param name="amenity">The amenity to update</param>
        /// <returns>Task of completion</returns>
        Task<Amenities> Update(Amenities amenity);

        /// <summary>
        /// Deletes an amenity
        /// </summary>
        /// <param name="id">Unique identifier of amenity</param>
        /// <returns>Task of completion</returns>
        Task Delete(int id);
    }
}
