using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IEmployee
    {
        public IEnumerable<EmployeeEntity> GetAllEmployees();

        public bool AddEmployee(EmployeeEntity e);
        public bool DeleteEmployee(string empId);

        public bool EditEmployee(EditEmployee empId);
        
    }
}
