using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models;

namespace HRMSApplication.Repository
{
    public class EmployeeRepository : IEmployee
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;
        public EmployeeRepository(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }
        //method to get the All Employees
        public List<Employee> GetAllEmployees()
        {
            log.LogInfo("get the All Employees");
            var query = "select *from Employees";
            using (var conn = edc.CreateConnection())
            {
                log.LogInfo("Get All Employees from repository");
                List<Employee> employees = (List<Employee>)conn.Query<Employee>(query);
                return employees.ToList();
            }

        }
    }
}
