using HRMSApplication.Models.Entity;

namespace HRMSApplication.Models
{
    public class LoginDetails
    {
        public IEnumerable<EmployeeEntity> Employees { get; set; }
        public string jwttoken { get; set; }

    }
}
