using System.ComponentModel.DataAnnotations;

namespace HRMSApplication.Models
{
    public class UserInput
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}
