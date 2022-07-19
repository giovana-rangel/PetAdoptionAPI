using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class FavPetDTO
    {
        public ICollection<PetViewModel> FavPets { get; set; }
    }
}
