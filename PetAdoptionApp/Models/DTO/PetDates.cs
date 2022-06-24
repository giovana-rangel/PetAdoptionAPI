using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class PetDates
    {
        public virtual int Id { get; set; }
        public virtual DateTime petCreation { get; set; }
    }
}
