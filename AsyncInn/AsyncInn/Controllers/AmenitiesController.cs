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
        private readonly AsyncInnDbContext _context;

        public AmenitiesController(IAmenities amenity, AsyncInnDbContext context)
        {
            _context = context;
            _amenity = amenity;
        }

        //// GET: api/Amenities
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Amenities>>> GetAllAmenities()
        //{
        //    return await _amenity.GetAllAmenities();
        //}

        // GET: api/Amenities/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Amenities>> GetAmenity(int id)
        //{
        //    return await _amenity.GetAmenity(id);
        //}

        // GET: api/Amenities/4
        [HttpGet]
        [Route("{id}")]
        public async Task<AmenityDTO> GetAmenity(int id)
        {
            return await _amenity.GetAmenity(id);
        }

        // GET: api/Amenities
        [HttpGet]
        public IQueryable<AmenityDTO> GetAmenities()
        {
            var amenities = from a in _context.Amenities
                            select new AmenityDTO()
                            {
                                Id = a.Id,
                                Name = a.Name
                            };
            return amenities;
        }      

        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
            if (id != amenities.Id)
            {
                return BadRequest();
            }
            var updatedAmenity = await _amenity.Update(amenities);
            return Ok(updatedAmenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenities)
        //{
        //    await _amenity.Create(amenities);
        //    return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
        //}

        // TODO: not working
        // POST: api/Amenities
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenity(Amenities amenity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();

            _context.Entry(amenity).Reference(a => a.Name).Load();


            var dto = new AmenityDTO()
            {
                Id = amenity.Id,
                Name = amenity.Name
            };
            return CreatedAtRoute("DefaultApi", new { id = amenity.Id }, dto);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            await _amenity.Delete(id);
            return NoContent();
        }

    }
}
