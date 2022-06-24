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
    public class TreatmentController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        public TreatmentController(PetAdoptionAppContext context)
        {
            _context = context;
        }

        // GET: PetApi/Treatment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treatment>>> GetTreatment()
        {
            return await _context.Treatments.ToListAsync();
        }

        // GET PetApi/Treatment5
        [HttpGet("{id}")]
        public ActionResult<List<Treatment>> GetTreatment(int id)
        {
            var treatments = new List<Treatment>();
            treatments = _context.Treatments.Where(t => t.PetIdFk == id).ToList<Treatment>();

            if (treatments == null)
            {
                return NotFound();
            }

            return treatments;
        }

        // POST PetApi/Treatment
        [HttpPost]
        public async Task<ActionResult<Treatment>> PostTreatment(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTreatment", new { id = treatment.Id }, treatment);

        }

        // PUT PetApi/Treatment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreatment(int id, Treatment treatment)
        {
            if (id != treatment.Id)
            {
                return BadRequest();
            }
            _context.Entry(treatment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentExists(id))
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

        // DELETE PetApi/Treatment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }

            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //useful methods
        private bool TreatmentExists(int id)
        {
            return _context.Treatments.Any(e => e.Id == id);
        }
    }
}
