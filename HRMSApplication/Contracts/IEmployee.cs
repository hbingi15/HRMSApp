using HRMSApplication.Models;

namespace HRMSApplication.Contracts
{
    public interface IEmployee
    {
        public List<Employee> GetAllEmployees();
        
        public Employee GetEmployee(int id);
        public bool hii();
        public Employee GetEmployee(Employee employee);

    }
}
