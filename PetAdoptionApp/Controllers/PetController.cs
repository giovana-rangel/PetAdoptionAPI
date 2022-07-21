using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using PetAdoptionApp.Models.DTO;
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

        // GET ALL RAW
        [HttpGet]
        public async Task<PetsMetaData> GetPets()
        {
            var pets = await _petService.GetAll();
            var petsDTO = _mapper.Map<IEnumerable<PetViewModel>>(pets);
            var petsMetaData = new PetsMetaData();
            petsMetaData.pets = petsDTO;
            petsMetaData.meta = petsDTO.Count();
            return petsMetaData;
        }

        //GET ALL WITH LIMIT EXTENSION
        [HttpGet("limit")]
        public async Task<PetsMetaData> GetSomePets([FromQuery] int value)
        {
            var pets = await _petService.GetAll();
            int count = pets.Count();
            var petsDTO = _mapper.Map<IEnumerable<PetViewModel>>(pets).Take(value);
            var petsMetaData = new PetsMetaData();
            petsMetaData.pets = petsDTO;
            petsMetaData.meta = count;
            return petsMetaData;
        }

        // GET ALL PETS BY USER ID
        [HttpGet("userId")]
        public async Task<IEnumerable<PetViewModel>> GetPetByUserId([FromQuery] int id)
        {
            var pets = await _petService.GetAll();
            var petsDTO = _mapper.Map<IEnumerable<PetViewModel>>(pets).Where(x => x.UserId == id);
            return petsDTO;
        }

        //GET ALL TREATMENTS AND VACINES BY PET
        [HttpGet("healthData")]
        public async Task<List<PetTreatments>> GetPetsHeathReport()
        {
            var pets = await _petService.GetAll();
            var treatments = await _context.Treatments.ToListAsync();
            var vacines = await _context.Vacines.ToListAsync();
            List<PetTreatments> petTreatments = new List<PetTreatments>();

            foreach (Pet p in pets)
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

        //Get Mascotas creadas por mes
        [HttpGet("date")]
        public async Task<List<int>> GetPetsByDate()
        {
            List<int> counts = new List<int>();
            var pets = await _petService.GetAll();
            var petDates = _mapper.Map<IEnumerable<PetDates>>(pets);

            for (int i = 1; i < 13; i++)
            {
                int value = petDates.Count(p => p.petCreation.Month == i && p.petCreation.Year == DateTime.Now.Year);
                counts.Add(value);
            }

            return counts;
        }

        // POST PET
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostPet(P p)
        {
            try
            {
                LocationAddress location = new LocationAddress();
                location.Id = 0;
                location.Country = p.Country;
                location.State = p.State;
                location.City = p.City;
                location.Street = p.Street;
                location.Number = p.Number;

                _context.LocationAddresses.Add(location);
                await _context.SaveChangesAsync();

                Pet pet = new Pet();
                pet.LocationIdFk = location.Id;
                pet.Id = p.Id;
                pet.PetName = p.PetName;
                pet.Bio = p.Bio;
                pet.Sex = p.Sex;
                pet.UserIdFk = p.UserIdFk;
                pet.Age = p.Age;
                pet.PetWeight = p.PetWeight;
                pet.IsAdopted = p.IsAdopted;
                pet.PetTypeIdFk = p.PetTypeIdFk;
                pet.ColorIdFk = p.ColorIdFk;
                pet.BreedIdFk = p.BreedIdFk;
                pet.ImageIdFk = null;

                var newPet = await _petService.CreateNew(pet);
                return CreatedAtAction("GetPet", new { id = newPet.Id }, newPet);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT PET
        [HttpPut("{locationId}")]
        public async Task<IActionResult> PutPet(int locationId, P p)
        {
            Pet pet = setPetData(p, locationId);
            LocationAddress location = setLocationAddress(p, locationId);

            _context.Entry(pet).State = EntityState.Modified;
            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(locationId))
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

        // DELETE PET
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
        private bool PetExists(int petId)
        {
            return _context.Pets.Any(e => e.Id == petId);
        }

        private bool LocationExists(int locationId)
        {
            return _context.LocationAddresses.Any(e => e.Id == locationId);
        }

        private LocationAddress setLocationAddress(P p, int locationId)
        {
            LocationAddress location = new LocationAddress();
            location.Id = locationId;
            location.Country = p.Country;
            location.State = p.State;
            location.City = p.City;
            location.Street = p.Street;
            location.Number = p.Number;

            return location;
        }
        private Pet setPetData(P p, int locationId)
        {

            Pet pet = new Pet();
            pet.LocationIdFk = locationId;
            pet.Id = p.Id;
            pet.PetName = p.PetName;
            pet.Bio = p.Bio;
            pet.Sex = p.Sex;
            pet.UserIdFk = p.UserIdFk;
            pet.Age = p.Age;
            pet.PetWeight = p.PetWeight;
            pet.IsAdopted = p.IsAdopted;
            pet.PetTypeIdFk = p.PetTypeIdFk;
            pet.ColorIdFk = p.ColorIdFk;
            pet.BreedIdFk = p.BreedIdFk;
            pet.ImageIdFk = null;

            return pet;
        }
    }
}
