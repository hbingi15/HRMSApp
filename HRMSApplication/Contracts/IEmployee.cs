

using HRMSApplication.Models;

namespace HRMSApplication.Contracts
{
    public interface IEmployee
    {
        public IEnumerable<EmployeeResource> GetAllEmployees();

        public bool AddEmployee(EmployeeResource e);
        public bool DeleteEmployee(EmployeeResource e);
        public bool UpdateEmployee( EmployeeResource e);



    }
}
