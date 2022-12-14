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

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string SurName { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string Designation { get; set; }

        [Required]
        public string  PersonalEmail{ get; set; }
        public string AltEmail { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string BloodGroup { get; set; }
        public int Rmanager_Id { get; set; }
        public int HR_Id { get; set; }
        public string JobGrade_Id { get; set; }
        public string OffEmail { get; set; }

    }
}
