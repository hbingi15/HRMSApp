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
        public IEnumerable<EmployeeResource> GetAllEmployees()
        {
            IEnumerable<EmployeeResource> employees = null;
            try
            {
                log.LogInfo("get the All Employees");
                var query = "select *from Employees";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All Employees from repository");
                    employees = (List<EmployeeResource>)conn.Query<EmployeeResource>(query);
                    return employees.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return employees.ToList();

        }

        public bool  AddEmployee(EmployeeResource e)
        {
            string query = "insert into Employees(empl_firstname, empl_lastname, empl_surname, empl_empid,empl_joindate, empl_dob, empl_designation, empl_offemail, empl_pemail,empl_mobile, empl_altemail, empl_bloodgroup, empl_gender,empl_address, empl_fathername) Values(@fnm,@lnm, @snm,@id,@jdt,@dob,@des,@ofmail,@pmail,@mbl,@amail,@bgrp,@empl_gender,@ads,@frnm)";
            try
            {
                using (var conn = edc.CreateConnection())
                {
                    conn.Open();
                    int nor = conn.Execute(query, new { @fnm = e.empl_firstname, @lnm = e.empl_lastname, @snm = e.empl_surname, @id = e.empl_empid, @jdt = e.empl_joindate, @dob = e.empl_dob, @des = e.empl_designation, @ofmail = e.empl_offemail, @pmail = e.empl_pemail, @mbl = e.empl_mobile, @amail = e.empl_altemail, @bgrp = e.empl_bloodgroup, @gn = e.empl_gender, @ads = e.empl_address, @frnm = e.empl_fatherName });
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

        public bool DeleteEmployee(EmployeeResource e)
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
        }
        public bool UpdateEmployee(EmployeeResource e)
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
