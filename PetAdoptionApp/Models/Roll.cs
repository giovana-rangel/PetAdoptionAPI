using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class Roll
    {
        public Roll()
        {
            UserClients = new HashSet<UserClient>();
        }

        public int Id { get; set; }
        public string ClientRole { get; set; }

        public virtual ICollection<UserClient> UserClients { get; set; }
    }
}
