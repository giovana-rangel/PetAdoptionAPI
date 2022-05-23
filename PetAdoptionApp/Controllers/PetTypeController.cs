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
    public class PetTypeController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        public PetTypeController(PetAdoptionAppContext context)
        {
            _context = context;
        }

        // GET: PetApi/UserClientRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetType>>> GetPetTypes()
        {
            return await _context.PetTypes.ToListAsync();
        }

        // GET PetApi/UserClientRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetType>> GetPetType(int id)
        {
            var petType = await _context.PetTypes.FindAsync(id);

            if (petType == null)
            {
                return NotFound();
            }

            return petType;
        }

        // POST PetApi/UserClientRole
        [HttpPost]
        public async Task<ActionResult<PetType>> PostPetType(PetType petType)
        {
            _context.PetTypes.Add(petType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebsiteLink", new { id = petType.Id }, petType);

        }

        // PUT PetApi/UserClientRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetTyp(int id, PetType petType)
        {
            if (id != petType.Id)
            {
                return BadRequest();
            }
            _context.Entry(petType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetTypeExists(id))
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
        public async Task<IActionResult> DeletePetTyp(int id)
        {
            var petType = await _context.PetTypes.FindAsync(id);
            if (petType == null)
            {
                return NotFound();
            }

            _context.PetTypes.Remove(petType);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //useful methods
        private bool PetTypeExists(int id)
        {
            return _context.PetTypes.Any(e => e.Id == id);
        }
    }
}
