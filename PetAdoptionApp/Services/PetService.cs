using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Models;
using PetAdoptionApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Services
{
    public class PetService : IPetService
    {
        private readonly PetAdoptionAppContext _context;
        public PetService(PetAdoptionAppContext context)
        {
            _context = context;
        }

        public async Task<Pet> CreateNew(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task<bool> Delete(int petId)
        {
            var pet = await _context.Pets.FindAsync(petId);
            if (pet == null)
            {
                return false;
            }
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Pet>> GetAll()
        {
            return await _context.Pets
                .Include(u => u.ImageIdFkNavigation)
                .Include(u => u.LocationIdFkNavigation)
                .Include(u => u.PetTypeIdFkNavigation)
                .Include(u => u.UserIdFkNavigation)
                .ToListAsync();
        }

        public async Task<Pet> GetById(int petId)
        {
            return await _context.Pets
                .Include(p => p.ImageIdFkNavigation)
                .Include(p => p.LocationIdFkNavigation)
                .Include(p => p.PetTypeIdFkNavigation)
                .Include(p => p.UserIdFkNavigation)
                .SingleOrDefaultAsync(p => p.Id == petId);
        }

        public Pet Update(int petId, Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
