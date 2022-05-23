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
    public class PictureController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;

        public PictureController(PetAdoptionAppContext context)
        {
            _context = context;
        }

        // GET: PetApi/<PictureController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Picture>>> GetPictures()
        {
            return await _context.Pictures.ToListAsync();
        }

        // GET api/<PictureController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Picture>> GetPicture(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);

            if (picture == null)
            {
                return NotFound();
            }

            return picture;
        }

        // POST api/<PictureController>
        [HttpPost]
        public async Task<ActionResult<Picture>> PostPicture(Picture picture)
        {
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPicture", new { id = picture.Id }, picture);
        }

        // PUT api/<PictureController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Picture>> PutPicture(int id, Picture picture)
        {
            if (id != picture.Id)
            {
                BadRequest();
            }

            _context.Entry(picture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PictureExists(id))
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

        // DELETE api/<PictureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePicture(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);
            if (picture == null)
            {
                return NotFound();
            }

            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //useful methods
        private bool PictureExists(int id)
        {
            return _context.Pictures.Any(e => e.Id == id);
        }
    }
}
