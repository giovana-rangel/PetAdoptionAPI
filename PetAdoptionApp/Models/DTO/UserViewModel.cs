﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class UserViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Bio { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Role { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual ICollection<FavPet> FavPets { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<WebsiteLink> WebsiteLinks { get; set; }
        public virtual LocationAddress Location { get; set; }

    }
}
