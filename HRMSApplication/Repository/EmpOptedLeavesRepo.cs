using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;

namespace HRMSApplication.Repository
{
    public class EmpOptedLeavesRepo : IEmpOptedLeaves
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;

        public EmpOptedLeavesRepo(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }

        //method to get the All Employees
        public IEnumerable<EmpOptedLeavesEntity> GetAllEmpOptedLeaves()
        {
            IEnumerable<EmpOptedLeavesEntity> employees = null;
            try
            {
                log.LogInfo("get the All Employees");
                var query = "select *from EmployeeOptedLeaves";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All Employees from repository");
                    employees = (List<EmpOptedLeavesEntity>)conn.Query<EmpOptedLeavesEntity>(query);
                    return employees.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return employees.ToList();

        }
        public bool AddEmpOptedLeave(EmpOptedLeavesEntity e)
        {
            string query = "insert into EmployeeOptedLeaves(empl_id,year_id,eolv_date,eolv_leavetype) Values(@empl_id,@year_id, @eolv_date,@eolv_leavetype)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee Opted Leaves");
                    int nor = conn.Execute(query, new { @empl_id = e.empl_id, @year_id = e.year_id, @eolv_date = e.eolv_date, @eolv_leavetype = e.eolv_leavetype });
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


    }
}