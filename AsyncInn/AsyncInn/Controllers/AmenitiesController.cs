using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenities _amenity;

        public AmenitiesController(IAmenities amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities/4
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            var amenities = await _amenity.GetAmenity(id);

            if (amenities == null)
                return NotFound();

            return amenities;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            return await _amenity.GetAllAmenities();
        }      

        // TODO: How do I run this in postman?
        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
            if (id != amenities.Id)
                return BadRequest();

            await _amenity.Update(amenities);
            return NoContent();
        }

        // POST: api/Amenities
        [HttpPost]
        public async Task<ActionResult<AmenityDTO>> PostAmenity(AmenityDTO amenity)
        {
            await _amenity.Create(amenity);
            return CreatedAtAction("GetAmenities", new { id = amenity.Id }, amenity);
        }

        // TODO: Is this working?
        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            await _amenity.Delete(id);
            return NoContent();
        }
    }
}
