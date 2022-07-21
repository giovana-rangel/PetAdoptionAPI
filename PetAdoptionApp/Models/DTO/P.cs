using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class P
    {
        public virtual int Id { get; set; }
        public virtual string PetName { get; set; }
        public virtual string Bio { get; set; }
        public virtual int Sex { get; set; }
        public virtual int Age { get; set; }
        public virtual double PetWeight { get; set; }
        public virtual int IsAdopted { get; set; }
        public virtual int PetTypeIdFk { get; set; }
        public virtual int ColorIdFk { get; set; }
        public virtual int BreedIdFk { get; set; }
        public virtual int UserIdFk { get; set; }
        public virtual int ImageIdFk { get; set; }
        public virtual string Country { get; set; }
        public virtual string State { get; set; }
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual int Number { get; set; }
    }
}
