using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class Color
    {
        public Color()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Color1 { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
