using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.EntityModels;
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
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = null;
            try
            {
                log.LogInfo("get the All Employees");
                var query = "select *from Employees";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All Employees from repository");
                    employees = (List<Employee>)conn.Query<EmployeeResource>(query);
                    return employees.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return employees.ToList();

        }
        public bool  AddEmployee(Employee e)
        {
            string query = "insert into Employees(empl_firstname, empl_lastname, empl_surname, empl_empid,empl_joindate, empl_dob, empl_designation, empl_offemail, empl_pemail,empl_mobile, empl_altemail, empl_bloodgroup, empl_gender,empl_address, empl_fathername) Values(@fnm,@lnm, @snm,@id,@jdt,@dob,@des,@ofmail,@pmail,@mbl,@amail,@bgrp,@empl_gender,@ads,@frnm)";
            try
            {
                using (var conn = edc.CreateConnection())
                {
                    conn.Open();
                    int nor = conn.Execute(query, new { @fnm = e.FirstName, @lnm = e.LastName, @snm = e.SurName, @id = e.EmpId, @jdt = e.Joiningdate, @dob = e.DOB, @des = e.Designation, @ofmail = e.OffEmail, @pmail = e.PersonalEmail, @mbl = e.Mobile, @amail = e.AlternativeEmail, @bgrp = e.BloodGroup, @gn = e.Gender, @ads = e.Address, @frnm = e.FatherName });
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
            catch (Exception msg)
            {
                throw msg;
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
        //public bool UpdateEmployee(EmployeeResource e)
        //{
        //    string query = "update Employees set empl_mobile=@empl_mobile,empl_address=@empl_address  where empl_id=@empl_id";
        //    using (var conn = edc.CreateConnection())
        //    {
        //        conn.Open();
        //        int nor = conn.Execute(query, new { @empl_mobile = e.empl_mobile, @empl_address = e.empl_address });
        //        if (nor == 1)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //        conn.Close();
        //    }
        //}
    }
}
