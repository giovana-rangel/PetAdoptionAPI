using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class PetLiteViewModel
    {
        public virtual int Id { get; set; }
        public virtual string PetName { get; set; }
        public virtual bool Sex { get; set; }
        public virtual string PetType { get; set; }
        public virtual int Number { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State{ get; set; }
    }
}
