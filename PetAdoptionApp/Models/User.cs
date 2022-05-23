using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvchar(100)")]
        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "nvchar(255)")]
        [Required]
        public string Bio { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime Birthdate { get; set; }

        [Column(TypeName = "nvchar(100)")]
        [Required]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime EmailVerifiedAt { get; set; }

        [Column(TypeName = "nvchar(15)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvchar(50)")]
        [Required]
        public string Password { get; set; }

        public bool Is_active { get; set; }
        public int WebsiteLinkId_FK { get; set; } 
        public int PicturePathId_FK { get; set; }
        public int LocationId_FK { get; set; }
        public int UserRoleId_FK { get; set; }
        public int RememberTokenId_FK { get; set; }
        public DateTime TimeStamps { get; set; }
    }
}
