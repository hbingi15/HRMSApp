namespace HRMSApplication.Models
{
    public class PasswordChange
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmationPassword { get; set; }
    }
}
