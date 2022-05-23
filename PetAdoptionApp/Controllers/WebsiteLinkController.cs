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
    public class WebsiteLinkController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        public WebsiteLinkController(PetAdoptionAppContext context)
        {
            _context = context;
        }

        // GET: PetApi/UserClientRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebsiteLink>>> GetWebsiteLinks()
        {
            return await _context.WebsiteLinks.ToListAsync();
        }

        // GET PetApi/UserClientRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebsiteLink>> GetWebsiteLink(int id)
        {
            var websiteLink = await _context.WebsiteLinks.FindAsync(id);

            if (websiteLink == null)
            {
                return NotFound();
            }

            return websiteLink;
        }

        // POST PetApi/UserClientRole
        [HttpPost]
        public async Task<ActionResult<WebsiteLink>> PostWebsiteLink(WebsiteLink websiteLink)
        {
            _context.WebsiteLinks.Add(websiteLink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebsiteLink", new { id = websiteLink.Id }, websiteLink);

        }

        // PUT PetApi/UserClientRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebsiteLink(int id, WebsiteLink websiteLink)
        {
            if (id != websiteLink.Id)
            {
                return BadRequest();
            }
            _context.Entry(websiteLink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteLinkExists(id))
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
        public async Task<IActionResult> DeleteWebsiteLink(int id)
        {
            var websiteLink = await _context.WebsiteLinks.FindAsync(id);
            if (websiteLink == null)
            {
                return NotFound();
            }

            _context.WebsiteLinks.Remove(websiteLink);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //useful methods
        private bool WebsiteLinkExists(int id)
        {
            return _context.WebsiteLinks.Any(e => e.Id == id);
        }
    }
}
