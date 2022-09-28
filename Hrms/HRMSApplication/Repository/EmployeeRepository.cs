using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<EmployeeEntity> GetAllEmployees()
        {
            IEnumerable<EmployeeEntity> employees = null;
            try
            {
                log.LogInfo("get the All Employees");
                var query = "select *from Employees";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All Employees from repository");
                    employees = (List<EmployeeEntity>)conn.Query<EmployeeEntity>(query);
                    return employees.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return employees.ToList();

        }
        //method to add new employee
        public bool  AddEmployee(EmployeeEntity e)
        {
            string query = "insert into Employees(empl_firstname, empl_lastname, empl_surname, empl_empid,empl_joindate, empl_dob, empl_designation, empl_offemail, empl_pemail,empl_mobile, empl_altemail, empl_bloodgroup, empl_gender,empl_address, empl_fathername) Values(@fnm,@lnm, @snm,@id,@jdt,@dob,@des,@ofmail,@pmail,@mbl,@amail,@bgrp,@gn,@ads,@frnm)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @fnm = e.empl_firstname, @lnm = e.empl_lastname, @snm = e.empl_surname,  @jdt = e.empl_joindate, @dob = e.empl_dob, @des = e.empl_designation, @ofmail = e.empl_offemail, @pmail = e.empl_pemail, @mbl = e.empl_mobile, @amail = e.empl_altemail, @bgrp = e.empl_bloodgroup, @gn = e.empl_gender, @ads = e.empl_address, @frnm = e.empl_fatherName });
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
        // used for deleting employee
        public bool DeleteEmployee(string empId)
        {
           using (var conn = edc.CreateConnection())
            {
                var str = empId;
                conn.Open();
                log.LogInfo("deleting employee function");
                int nor = conn.Execute("update Employees set Employee_status='Deleted' where empl_id=@eid", new {eid=str});
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
        //used to update the employee
        public bool EditEmployee(EditEmployee empId)
        {
              using (var conn = edc.CreateConnection()) 
              {
                var str = empId;
                conn.Open();
                log.LogInfo("update the employee function");
                int nor = conn.Execute("update Employees set empl_mobile=@mb,empl_address=@adr  where empl_id=@empid", new {empid =empId.emp_id,mb=empId.empl_mobile,adr=empId.empl_address});

                if ( nor==1)
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
