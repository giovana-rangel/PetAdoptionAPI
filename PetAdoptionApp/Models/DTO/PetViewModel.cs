using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class PetViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Bio { get; set; }
        public virtual string Breed { get; set; }
        public virtual int Color { get; set; }
        public virtual bool Sex { get; set; }
        public virtual bool Age { get; set; }
        public virtual double Weight { get; set; }
        public virtual bool Is_adopted { get; set; }
        public virtual string PetType { get; set; }
        public virtual string Username { get; set; }
        public virtual int UserId { get; set; }
        public virtual int LocationId { get; set; }
        public virtual string Country { get; set; }
        public virtual string State { get; set; }
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual int Number { get; set; }
    }
}
