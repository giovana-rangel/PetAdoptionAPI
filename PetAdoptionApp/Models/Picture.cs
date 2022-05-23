using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class Picture
    {
        public Picture()
        {
            Pets = new HashSet<Pet>();
            UserClients = new HashSet<UserClient>();
        }

        public int Id { get; set; }
        public string PicturePath { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<UserClient> UserClients { get; set; }
    }
}
