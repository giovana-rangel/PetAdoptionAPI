using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class Treatment
    {
        public int Id { get; set; }
        public string TreatmentLabel { get; set; }
        public DateTime? AplicationDate { get; set; }
        public int? PetIdFk { get; set; }

        public virtual Pet PetIdFkNavigation { get; set; }
    }
}
