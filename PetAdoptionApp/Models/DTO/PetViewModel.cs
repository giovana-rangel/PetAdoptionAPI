using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class PetViewModel
    {
        public virtual int Id { get; set; }
        public virtual string PetName { get; set; }
        public virtual string Bio { get; set; }
        public virtual string Breed { get; set; }
        public virtual string Sex { get; set; }
        public virtual int? Age { get; set; }
        public virtual double? PetWeight { get; set; }
        public virtual string Color { get; set; }
        public virtual string Username { get; set; }
        public virtual int UserId { get; set; }
        public virtual LocationAddress Location { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
        public virtual ICollection<Vacine> Vacines { get; set; }
    }
}
