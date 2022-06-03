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
    public class VacineController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        public VacineController(PetAdoptionAppContext context)
        {
            _context = context;
        }

        // GET: PetApi/UserClientRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacine>>> GetVacines()
        {
            return await _context.Vacines.ToListAsync();
        }

        // GET PetApi/UserClientRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacine>> GetVacine(int id)
        {
            var vacine = await _context.Vacines.FindAsync(id);

            if (vacine == null)
            {
                return NotFound();
            }

            return vacine;
        }

        // POST PetApi/UserClientRole
        [HttpPost]
        public async Task<ActionResult<Vacine>> PostVacines(Vacine vacine)
        {
            _context.Vacines.Add(vacine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacine", new { id = vacine.Id }, vacine);

        }

        // PUT PetApi/UserClientRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacines(int id, Vacine vacine)
        {
            if (id != vacine.Id)
            {
                return BadRequest();
            }
            _context.Entry(vacine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacineExists(id))
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
        public async Task<IActionResult> DeleteVacines(int id)
        {
            var vacine = await _context.Vacines.FindAsync(id);
            if (vacine == null)
            {
                return NotFound();
            }

            _context.Vacines.Remove(vacine);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //useful methods
        private bool VacineExists(int id)
        {
            return _context.Vacines.Any(e => e.Id == id);
        }
    }
}
