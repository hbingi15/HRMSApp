﻿using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models;

namespace HRMSApplication.Repository
{
    public class IEmployeeRepo : IEmployee
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;
        public IEmployeeRepo(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }
        //method to get the All Employees
        public IEnumerable<Employee> GetAllEmployees()
        {
            log.LogInfo("get the All Employees");
            var query = "select *from Employees";
            using (var conn = edc.CreateConnection())
            {
                log.LogInfo("Get All Employees from repository");
                IEnumerable<Employee> employees = (IEnumerable<Employee>)conn.Query<Employee>(query);
                return employees.ToList();
            }

        }
        public bool  AddEmployee(Employee e)
        {
            string query = "insert into Employees(empl_firstname, empl_lastname, empl_surname, empl_empid,empl_joindate, empl_dob, empl_designation, empl_offemail, empl_pemail,empl_mobile, empl_altemail, empl_bloodgroup, empl_gender,empl_address, empl_fathername,Employee_status) Values(@empl_firstname,@empl_lastname, @empl_surname,@empl_empid,@empl_joindate,@empl_dob,@empl_designation,@empl_offemail,@empl_pemail,@empl_mobile,@empl_altemail,@empl_bloodgroup,@empl_gender,@empl_address,@empl_fathername,Employee_status)";
            using (var conn = edc.CreateConnection())
            {
                conn.Open();
                int nor = conn.Execute(query, new { @empl_firstname = e.empl_firstname, @empl_lastname = e.empl_lastname, @empl_surname = e.empl_surname, @empl_empid = e.empl_empid, @empl_joindate = e.empl_joindate, @empl_dob = e.empl_dob, @empl_designation = e.empl_designation, @empl_offemail = e.empl_offemail, @empl_pemail = e.empl_pemail, @empl_mobile = e.empl_mobile, @empl_altemail = e.empl_altemail, @empl_bloodgroup = e.empl_bloodgroup, @empl_gender = e.empl_gender, @empl_address = e.empl_address, @empl_fathername = e.empl_fatherName, @Employee_status = e.Employee_status });
                if (nor == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                conn.Close();
            }
        }
        /*public bool DeleteEmployee(Employee e)
        {
            var query = "Delete Employees set Employee_status='Deleted' where empl_id=@empl_id;";
            using (var conn = edc.CreateConnection())
            {
                conn.Open();
                int nor = conn.Execute(query, new { @empl_id = e.empl_id });
                if (nor == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }*/
        public bool UpdateEmployee(Employee e)
        {
            string query = "update Employees set empl_mobile=@empl_mobile,empl_address=@empl_address  where empl_id=@empl_id";
            using (var conn = edc.CreateConnection())
            {
                conn.Open();
                int nor = conn.Execute(query, new { @empl_mobile = e.empl_mobile, @empl_address = e.empl_address });
                if (nor == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                conn.Close();
            }
        }
    }
}
