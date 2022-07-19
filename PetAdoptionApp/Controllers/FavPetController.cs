using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using PetAdoptionApp.Models.DTO;
using PetAdoptionApp.Services.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IPetService _petService;
        public FavPetController
        (
            PetAdoptionAppContext context, 
            IMapper mapper,
            IPetService petService
        )
        {
            _context = context;
            _mapper = mapper;
            _petService = petService;
        }

        // GET ALL FAV PETS 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavPet>>> GetFavPets()
        {
            return await _context.FavPets.ToListAsync();
        }

        // GET ALL FAVPETS BY USER ID
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PetViewModel>>> GetFavPet(int id)
        {
            var favpets = await _context.FavPets.Where( x => x.UserIdFk == id).ToListAsync();
            if (favpets == null)
            {
                return NotFound();
            }

            var pets = new List<PetViewModel>();
            foreach (var f in favpets)
            {
                int petId = f.PetIdFk;
                var pet = await _petService.GetById(petId);

                if (pet == null)
                {
                    return NotFound();
                }

                var petViewModel = _mapper.Map<PetViewModel>(pet);
                pets.Add(petViewModel);
            }

            return pets;
        }

        // GET ALL FAVPETS BY USER ID VERSION LITE
        [HttpGet("user")]
        public async Task<ActionResult<List<int>>> GetFavs([FromQuery] int id)
        {
            var favs = await _context.FavPets.Where(x => x.UserIdFk == id).ToListAsync();
            
            if (favs == null){return NotFound();}

            List<int> favoritos = new List<int>();
            foreach(var f in favs){favoritos.Add(f.PetIdFk);}
            return favoritos;
        }

        //COUNTER LIKES BY PET ID
        [HttpGet("favPetId")]
        public async Task<int> CountLikesByPet([FromQuery] int favPetId)
        {
            var likes = await _context.FavPets.Where(x => x.PetIdFk == favPetId).ToListAsync();
            int counts = likes.Count();
            return counts;
        }

        // POST 
        [HttpPost]
        public async Task<ActionResult<FavPet>> PostFavPet(FavPet favpet)
        {
            _context.FavPets.Add(favpet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavPet", new { id = favpet.Id }, favpet);
        }

        // PUT 
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
