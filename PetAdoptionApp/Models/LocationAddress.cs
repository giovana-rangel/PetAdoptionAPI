using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class LocationAddress
    {
        public LocationAddress()
        {
            Pets = new HashSet<Pet>();
            UserClients = new HashSet<UserClient>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<UserClient> UserClients { get; set; }
    }
}
