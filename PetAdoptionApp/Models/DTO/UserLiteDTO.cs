using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class UserLiteDTO
    {
        public virtual string Username { get; set; }
        public virtual LocationAddress Location { get; set; }
        public virtual string ImagePath { get; set; }
    }
}
