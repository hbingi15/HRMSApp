using System.ComponentModel.DataAnnotations;

namespace HRMSApplication.Models
{
    public class ChangePassword
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
