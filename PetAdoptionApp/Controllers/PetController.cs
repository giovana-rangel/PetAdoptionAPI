using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using PetAdoptionApp.Models.DTO;
using PetAdoptionApp.Profiles;
using PetAdoptionApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PetAdoptionApp.Controllers
{
    [Route("PetApi/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetAdoptionAppContext _context;
        private readonly IMapper _mapper;
        private readonly IPetService _petService;
        public PetController
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

        // GET: PetApi/Pet
        [HttpGet]
        public async Task<IEnumerable<PetLiteViewModel>> GetPets()
        {
            var pets = await _petService.GetAll();
            var petLiteDTO = _mapper.Map<IEnumerable<PetLiteViewModel>>(pets);
            return petLiteDTO;
        }

        // GET: PetApi/Pet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetViewModel>> GetPet(int id)
        {
            var pet = await _petService.GetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            var petDTO = _mapper.Map<PetViewModel>(pet);
            return petDTO;
        }

        // POST: PetApi/User
        [HttpPost]
        //[Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostPet(Pet pet)
        {
            try
            {
                var newPet = await _petService.CreateNew(pet);
                return CreatedAtAction("GetPet", new { id = newPet.Id }, newPet);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: PetApi/Pet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }
            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
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

        // DELETE: PetApi/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //useful methods
        private bool Exists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
