using System;
using System.Collections.Generic;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class WebsiteLink
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int? UserIdFk { get; set; }

        public virtual UserClient UserIdFkNavigation { get; set; }
    }
}
