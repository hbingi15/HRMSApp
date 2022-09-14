using HRMSApplication.Models;

namespace HRMSApplication.Contracts
{
    public interface IEmployee
    {
        public List<Employee> GetAllEmployees();
        public bool hi();
        public bool bye();

    }
}
