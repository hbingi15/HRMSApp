using HRMSApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IAdminEmployee
    {
        public IEnumerable<EmployeeEntity> GetAllEmployees();

        public bool AddEmployee(EmployeeEntity e);
        public bool DeleteEmployee(string empId);
        public bool EditEmployee(AdminEditEmployee empId);
    }
}
