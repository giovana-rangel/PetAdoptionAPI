using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class PetType
    {
        public PetType()
        {
            Breeds = new HashSet<Breed>();
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string PetType1 { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
