using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetAdoptionApp.Controllers
{
    [Route("PetApi/[controller]")]
    [ApiController]
    public class FavPetController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        public FavPetController(PetAdoptionAppContext context)
        {
            _context = context;
        }

        // GET: PetApi/UserClientRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavPet>>> GetFavPets()
        {
            return await _context.FavPets.ToListAsync();
        }

        // GET PetApi/UserClientRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavPet>> GetFavPet(int id)
        {
            var favpet = await _context.FavPets.FindAsync(id);

            if (favpet == null)
            {
                return NotFound();
            }

            return favpet;
        }

        // POST PetApi/UserClientRole
        [HttpPost]
        public async Task<ActionResult<FavPet>> PostFavPet(FavPet favpet)
        {
            _context.FavPets.Add(favpet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebsiteLink", new { id = favpet.Id }, favpet);
        }

        // PUT PetApi/UserClientRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavPet(int id, FavPet favpet)
        {
            if (id != favpet.Id)
            {
                return BadRequest();
            }
            _context.Entry(favpet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavPetExists(id))
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

        // DELETE PetApi/UserClientRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavPet(int id)
        {
            var favpet = await _context.FavPets.FindAsync(id);
            if (favpet == null)
            {
                return NotFound();
            }

            _context.FavPets.Remove(favpet);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //useful methods
        private bool FavPetExists(int id)
        {
            return _context.FavPets.Any(e => e.Id == id);
        }
    }
}
