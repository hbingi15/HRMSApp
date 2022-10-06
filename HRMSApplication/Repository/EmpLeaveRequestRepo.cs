using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;
using NLog.Fluent;

namespace HRMSApplication.Repository
{
    public class EmpLeaveRequestRepo : IEmpLeaveRequest
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;
        public EmpLeaveRequestRepo(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }

        public IEnumerable<EmpLeaveRequestEntity> GetAllEmployeeRequest()
        {
            IEnumerable<EmpLeaveRequestEntity> employees = null;
            try
            {
                log.LogInfo("get the All Employees");
                var query = "select *from EmployeeLeaveRequests";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All Employees from repository");
                    employees = (List<EmpLeaveRequestEntity>)conn.Query<EmpLeaveRequestEntity>(query);
                    return employees.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return employees.ToList();

        }

        public bool AddEmployeeLeaveRequest(EmpLeaveRequestEntity e)
        {
            string query = "insert into employeeleaverequests(empl_id,elrq_index,elrq_date,elrq_leavetype,elrq_reason,elrq_leavestdate,elrq_leaveenddate,elrq_approvedby,elrq_approvedremarks,elrq_aprvdleavestdate,elrq_aprvdleaveenddate) Values(@empl_id,@elrq_index, @elrq_date,@elrq_leavetype,@elrq_reason,@elrq_leavestdate,@elrq_leaveenddate,@elrq_approvedby,@elrq_approvedremarks,@elrq_aprvdleavestdate,@elrq_aprvdleaveenddate)";
            try
            {
                using (var conn = edc.CreateConnection())
                {
                  conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @empl_id = e.empl_id, @elrq_index = e.elrq_index, @elrq_date = e.elrq_date, @elrq_leavetype = e.elrq_leavetype, @elrq_reason = e.elrq_reason, @elrq_leavestdate = e.elrq_leavestdate, @elrq_leaveenddate = e.elrq_leaveenddate, @elrq_approvedby = e.elrq_approvedby, @elrq_approvedremarks = e.elrq_approvedremarks, @elrq_aprvdleavestdate = e.elrq_aprvdleavestdate, @elrq_aprvdleaveenddate = e.elrq_aprvdleaveenddate });
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