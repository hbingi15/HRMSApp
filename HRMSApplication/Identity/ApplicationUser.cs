using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HRMSApplication.Identity
{
    //ApplicationUser class,we extend the IdentityUser class with  additional properties
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public byte UserLevel { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }
    }
}

