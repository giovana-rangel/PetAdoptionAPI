﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class Pet
    {
        public Pet()
        {
            FavPets = new HashSet<FavPet>();
            Treatments = new HashSet<Treatment>();
            Vacines = new HashSet<Vacine>();
        }

        public int Id { get; set; }
        public string PetName { get; set; }
        public string Bio { get; set; }
        public decimal? Sex { get; set; }
        public decimal? Age { get; set; }
        public double? PetWeight { get; set; }
        public decimal? IsAdopted { get; set; }
        public int? PetTypeIdFk { get; set; }
        public int? ColorIdFk { get; set; }
        public int? BreedIdFk { get; set; }
        public int? UserIdFk { get; set; }
        public int? ImageIdFk { get; set; }
        public int? LocationIdFk { get; set; }
        public DateTime? Timestamps { get; set; }

        public virtual Breed BreedIdFkNavigation { get; set; }
        public virtual Color ColorIdFkNavigation { get; set; }
        public virtual Picture ImageIdFkNavigation { get; set; }
        public virtual LocationAddress LocationIdFkNavigation { get; set; }
        public virtual PetType PetTypeIdFkNavigation { get; set; }
        public virtual UserClient UserIdFkNavigation { get; set; }
        public virtual ICollection<FavPet> FavPets { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
        public virtual ICollection<Vacine> Vacines { get; set; }
    }
}
