

using HRMSApplication.Models;

namespace HRMSApplication.Contracts
{
    public interface IEmployee
    {
        public IEnumerable<EmployeeResource> GetAllEmployees();

        public bool AddEmployee(EmployeeResource e);
        public bool DeleteEmployee(string empId);

        public bool EditEmployee(EditEmployee empId);
    }
}
