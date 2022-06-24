using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class Breed
    {
        public Breed()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Breed1 { get; set; }
        public int? PetTypeIdFk { get; set; }

        public virtual PetType PetTypeIdFkNavigation { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
