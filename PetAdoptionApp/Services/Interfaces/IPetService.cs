using PetAdoptionApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetAdoptionApp.Services.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAll();
        Task<Pet> GetById(int petId);
        Task<Pet> CreateNew(Pet pet);
        Pet Update(int petId, Pet pet);
        Task<bool> Delete(int petId);
    }
}
