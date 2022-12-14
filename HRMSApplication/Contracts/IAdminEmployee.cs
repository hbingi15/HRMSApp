
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IAdminEmployee
    {
        public Task<IEnumerable<EmployeeEntity>> GetAllEmployees();

        public bool AddEmployee(EmployeeEntity e);
        public bool DeleteEmployee(int empId);
        public bool EditEmployee(AdminEditEmployee empId);
        //public List<EmployeeEntity> GetAllEmployeesWithAutoMapper();
    }
}
