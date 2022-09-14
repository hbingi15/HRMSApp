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
        public bool AddEmployee(Employee e)
        {
            string query = "insert into Employees(empl_firstname, empl_lastname, empl_surname, empl_empid,empl_joindate, empl_dob, empl_designation, empl_offemail, empl_pemail,empl_mobile, empl_altemail, empl_bloodgroup, empl_gender,empl_address, empl_fathername) Values(@empl_firstname,@empl_lastname, @empl_surname,@empl_empid,@empl_joindate,@empl_dob,@empl_designation,@empl_offemail,@empl_pemail,@empl_mobile,@empl_altemail,@empl_bloodgroup,@empl_gender,@empl_address,@empl_fathername)";
            using (var conn = edc.CreateConnection())
            {
                conn.Open();
                int nor = conn.Execute(query, new { @empl_firstname = e.empl_firstname, @empl_lastname = e.empl_lastname, @empl_surname = e.empl_surname, @empl_empid = e.empl_empid, @empl_joindate = e.empl_joindate, @empl_dob = e.empl_dob, @empl_designation = e.empl_designation, @empl_offemail = e.empl_offemail, @empl_pemail = e.empl_pemail, @empl_mobile = e.empl_mobile, @empl_altemail = e.empl_altemail, @empl_bloodgroup = e.empl_bloodgroup, @empl_gender = e.empl_gender, @empl_address = e.empl_address, @empl_fathername = e.empl_fatherName });
                if (nor == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
