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
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [Authorize(Policy = "TierThree")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            var amenities = await _amenity.GetAmenity(id);

            if (amenities == null)
                return NotFound();

            return amenities;
        }

        // GET: api/Amenities
        [HttpGet]
        [Authorize(Policy = "TierThree")]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            return await _amenity.GetAllAmenities();
        }

        // PUT: api/Amenities/5
        [HttpPut("{id}")]
        [Authorize(Policy = "TierTwo")]
        public async Task<IActionResult> PutAmenity(int id, Amenities amenities)
        {
            if (id != amenities.Id)
                return BadRequest();

            await _amenity.Update(amenities);
            return NoContent();
        }

        // POST: api/Amenities
        [Authorize(Policy = "TierTwo")]
        [HttpPost]
        public async Task<ActionResult<AmenityDTO>> PostAmenity(AmenityDTO amenity)
        {
            await _amenity.Create(amenity);
            return CreatedAtAction("GetAmenities", new { id = amenity.Id }, amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "TierTwo")]
        public async Task<ActionResult<Amenities>> DeleteAmenity(int id)
        {
            await _amenity.Delete(id);
            return NoContent();
        }
    }
}