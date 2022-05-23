using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class UserClient
    {
        public UserClient()
        {
            FavPets = new HashSet<FavPet>();
            Pets = new HashSet<Pet>();
            WebsiteLinks = new HashSet<WebsiteLink>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Phone { get; set; }
        public string UserPassword { get; set; }
        public decimal? IsActive { get; set; }
        public int? RollIdFk { get; set; }
        public int? LocationIdFk { get; set; }
        public int? ImageIdFk { get; set; }
        public DateTime? Timestamps { get; set; }

        public virtual Picture ImageIdFkNavigation { get; set; }
        public virtual LocationAddress LocationIdFkNavigation { get; set; }
        public virtual Roll RollIdFkNavigation { get; set; }
        public virtual ICollection<FavPet> FavPets { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<WebsiteLink> WebsiteLinks { get; set; }
    }
}
