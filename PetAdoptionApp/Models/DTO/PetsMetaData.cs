using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models.DTO
{
    public class PetsMetaData
    {
        public PetsMetaData()
        {
            meta = 0;
        }
        public virtual IEnumerable<PetViewModel> pets {get; set;}
        public virtual int meta { get; set; }
    }
}
