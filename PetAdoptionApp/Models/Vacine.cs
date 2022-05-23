using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class Vacine
    {
        public int Id { get; set; }
        public string VacineLabel { get; set; }
        public string AplicationPlace { get; set; }
        public DateTime? AplicationDate { get; set; }
        public int? PetIdFk { get; set; }

        public virtual Pet PetIdFkNavigation { get; set; }
    }
}
