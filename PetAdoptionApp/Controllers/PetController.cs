﻿using AutoMapper;
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

        // GET ALL
        [HttpGet]
        public async Task<IEnumerable<PetViewModel>> GetPets()
        {
            var pets = await _petService.GetAll();
            var petDTO = _mapper.Map<IEnumerable<PetViewModel>>(pets);
            return petDTO;
        }

        //GET ALL WITH LIMIT EXTENSION
        [HttpGet("limit")]
        public async Task<IEnumerable<PetViewModel>> GetSomePets([FromQuery] int value)
        {
            var pets = await _petService.GetAll();
            var petDTO = _mapper.Map<IEnumerable<PetViewModel>>(pets).Take(value);
            return petDTO;
        }

        //GET ALL TREATMENTS AND VACINES BY PET
        [HttpGet("healthData")]
        public async Task<List<PetTreatments>> GetPetsTreatments()
        {
            var pets = await _petService.GetAll();
            var treatments = await _context.Treatments.ToListAsync();
            var vacines = await _context.Vacines.ToListAsync();
            List<PetTreatments> petTreatments = new List<PetTreatments>();

            foreach(Pet p in pets)
            {
                PetTreatments petTreatment = new PetTreatments();
                petTreatment.Id = p.Id;
                petTreatment.PetName = p.PetName;
                petTreatment.PetType = p.PetTypeIdFk;
                petTreatment.UserIdFk = p.UserIdFk;
                var treatment = treatments.Where(x => x.PetIdFk == p.Id).Select(x => x.TreatmentLabel).ToList();
                var vacine = vacines.Where(x => x.PetIdFk == p.Id).Select(x => x.VacineLabel).ToList();
                petTreatment.Treatments = treatment;
                petTreatment.Vacines = vacine;
                petTreatments.Add(petTreatment);
            }
            return petTreatments;
        }

        // GET PET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PetViewModel>> GetPet(int id)
        {
            var pet = await _petService.GetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            var petViewModel = _mapper.Map<PetViewModel>(pet);
            return petViewModel;
        }

        //GET BY RAZA (BREED)
        [HttpGet("search")]
        public async Task<IEnumerable<PetViewModel>> GetPets([FromQuery]string value)
        {
            var pets = await _petService.GetAll();

            var petDTO = _mapper.Map<IEnumerable<PetViewModel>>(pets).Where(x => x.Breed.ToLower().Contains(value));
            return petDTO;
        }

        //GET BY COLOR
        [HttpGet("color")]
        public async Task<IEnumerable<PetViewModel>> GetPetsByColor([FromQuery] int value)
        {
            var pets = await _petService.GetAll();

            var petDTO = _mapper.Map<IEnumerable<PetViewModel>>(pets).Where(x => x.Color == value);
            return petDTO;
        }

        //GET BY SEX (FEM/MASC)
        [HttpGet("sex")]
        public async Task<IEnumerable<PetViewModel>> GetPetsBySex([FromQuery] bool value)
        {
            var pets = await _petService.GetAll();
            var petDTO = _mapper.Map<IEnumerable<PetViewModel>>(pets).Where(x => x.Sex == value);
            return petDTO;
        }

        //Get Mascotas creadas por mes
        [HttpGet("date")]
        public async Task<List<int>> GetPetsByDate()
        {
            List<int> counts = new List<int>();
            var pets = await _petService.GetAll();
            var petDates = _mapper.Map<IEnumerable<PetDates>>(pets);
            
            for(int i = 1; i<13; i++)
            {
                int value = petDates.Count( p => p.petCreation.Month == i && p.petCreation.Year == DateTime.Now.Year) ;
                counts.Add(value);
            }

            return counts;
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
