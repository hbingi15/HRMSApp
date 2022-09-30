using AutoMapper;
using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;
using HRMSApplication.Profie;

namespace HRMSApplication.Repository
{
    public class AdminEmployeeRepository : IAdminEmployee
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;
        IMapper mapper;

        public AdminEmployeeRepository(EmployeeDapperContext edc, ILoggerManager log, IMapper mapper)
        {
            this.edc = edc;
            this.log = log;
            this.mapper = mapper;
        }
        /*public List<EmployeeEntity> GetAllEmployeesWithAutoMapper()
        {

            //return employees.ToList();
            List<EmployeeResource> er = new List<EmployeeResource>();
            //var conn = edc.CreateConnection();
            //var query = "select * from EmployeeEntity";
            //var data =  mapper.Map<List<EmployeeResource>, List<EmployeeEntity>>((List<EmployeeResource>)edc.EmployeeResource);
            return er;
        }
*/
        //method to get the All Employees
        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployees()
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
        public bool AddEmployee(EmployeeEntity e)
        {
            string query = "insert into Employees(empl_firstname, empl_lastname, empl_surname,empl_joindate, empl_dob, empl_designation, empl_offemail, empl_pemail,empl_mobile, empl_altemail, empl_bloodgroup, empl_gender,empl_address, empl_fathername) Values(@fnm,@lnm, @snm,@jdt,@dob,@des,@ofmail,@pmail,@mbl,@amail,@bgrp,@gn,@ads,@frnm)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @fnm = e.empl_firstname, @lnm = e.empl_lastname, @snm = e.empl_surname, @jdt = e.empl_joindate, @dob = e.empl_dob, @des = e.empl_designation, @ofmail = e.empl_offemail, @pmail = e.empl_pemail, @mbl = e.empl_mobile, @amail = e.empl_altemail, @bgrp = e.empl_bloodgroup, @gn = e.empl_gender, @ads = e.empl_address, @frnm = e.empl_fatherName });
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
                int nor = conn.Execute("update Employees set Employee_status='Not Active' where empl_empid=@eid", new { eid = str });
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
        public bool EditEmployee(AdminEditEmployee empId)
        {
            using (var conn = edc.CreateConnection())
            {
                var str = empId;
                conn.Open();
                log.LogInfo("update the employee function");
                int nor = conn.Execute("update Employees set empl_designation=@des,empl_mobile=@mb,empl_address=@adr  where empl_id=@empid", new { empid = empId.empl_id, des = empId.empl_designation, mb = empId.empl_mobile, adr = empId.empl_address });

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
