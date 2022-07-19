using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using PetAdoptionApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace PetAdoptionApp.Controllers
{
    [Route("PetApi/[controller]")]
    [ApiController]
    public class LocationAddressController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        private readonly IMapper _mapper;
        public LocationAddressController(PetAdoptionAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: PetApi/LocationAddress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationAddress>>> GetLocations()
        {
            return await _context.LocationAddresses.ToListAsync();
        }

        // GET PetApi/LocationAddress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> GetLocation(int id)
        {
            var location = await _context.LocationAddresses.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            var locationDTO = _mapper.Map<LocationDTO>(location);
            return locationDTO;
        }

        // POST PetApi/LocationAddress
        [HttpPost]
        public async Task<ActionResult<LocationAddress>> PostLocation(LocationAddress location)
        {
            _context.LocationAddresses.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, LocationAddress location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }
            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.LocationAddresses.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.LocationAddresses.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //useful methods
        private bool LocationExists(int id)
        {
            return _context.LocationAddresses.Any(e => e.Id == id);
        }
    }
}
