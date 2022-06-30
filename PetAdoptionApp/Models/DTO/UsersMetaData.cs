using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class UsersMetaData
    {
        public virtual IEnumerable<UserViewModel> Users {get; set;}
        public virtual int Entries { get; set; }
    }
}
