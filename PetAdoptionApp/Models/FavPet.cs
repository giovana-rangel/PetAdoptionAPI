using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class FavPet
    {
        public int Id { get; set; }
        public int UserIdFk { get; set; }
        public int PetIdFk { get; set; }

        public virtual Pet PetIdFkNavigation { get; set; }
        public virtual UserClient UserIdFkNavigation { get; set; }
    }
}
