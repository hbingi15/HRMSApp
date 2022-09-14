using HRMSApplication.Models;

namespace HRMSApplication.Contracts
{
    public interface IEmployee
    {
        public IEnumerable<Employee> GetAllEmployees();

        public bool AddEmployee(Employee e);
        //public bool DeleteEmployee(Employee e);
        public bool UpdateEmployee( Employee e);



    }
}
