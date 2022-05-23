using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PetAdoptionApp.Controllers
{
    [Route("PetApi/[controller]")]
    [ApiController]
    public class RollController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        public RollController(PetAdoptionAppContext context)
        {
            _context = context;
        }

        // GET: PetApi/UserClientRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roll>>> GetRoles()
        {
            return await _context.Rolls.ToListAsync();
        }

        // GET PetApi/UserClientRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roll>> GetRole(int id)
        {
            var role = await _context.Rolls.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // POST PetApi/UserClientRole
        [HttpPost]
        public async Task<ActionResult<Roll>> PostRole(Roll role)
        {
            _context.Rolls.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);

        }

        // PUT PetApi/UserClientRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Roll role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }
            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _context.Rolls.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Rolls.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //useful methods
        private bool RoleExists(int id)
        {
            return _context.Rolls.Any(e => e.Id == id);
        }
    }
}
