using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class PetTreatments
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public int? PetType{ get; set; } 
        public int? UserIdFk { get; set; }
        public List<string> Treatments { get; set; }
        public List<string> Vacines { get; set; }
    }
}
