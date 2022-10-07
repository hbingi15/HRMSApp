using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;
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

        //----------------Insert Employee Leave Request details to database------------------
        public bool ApplyLeaveRequest(LeaveRequestInput el)
        {
            string query1 = "select elrq_index from employeeleaverequests where empl_id=@id order by elrq_index desc limit 1";
            int index = 0;
            string query = "insert into employeeleaverequests(empl_id,elrq_index,elrq_date,elrq_leavetype,elrq_reason,elrq_leavestdate,elrq_leaveenddate,elrq_aprvdleavestdate) Values(@id,@inx,now(),@rq_type,@reason,@stdate,@enddate,now())";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("Insert Employee Leave Request details to database");

                    index = conn.ExecuteScalar<int>(query1, new { @id = el.Id });

                    if (index != 0)
                    {
                        int nor = conn.Execute(query, new { @id = el.Id, @inx = index + 1, @rq_type = el.LeaveType, @reason = el.Reason, @stdate = el.StartDate, @enddate = el.EndDate });
                        if (nor == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        int nor = conn.Execute(query, new { @id = el.Id, @inx = 1, @rq_type = el.LeaveType, @reason = el.Reason, @stdate = el.StartDate, @enddate = el.EndDate });
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
            catch (Exception msg)
            {
                throw msg;
            }
        }
        //------------Leave Request Approved by Respective HR and update in database-------------
        public string ApprovedByHr(UpdateRequestInput ur)
        {

            string query1 = "select elrq_index from employeeleaverequests where empl_id=@id order by elrq_index desc limit 1";
            //string query2 = "select empl_jbgr_id from employees where empl_id =@id";
            //string query3 = "select jbgr_nocl, jbgr_nosl, jbgr_nool from jobgradewiseleaves where jbgr_id =@grd";
            string query4 = "update employeeleaverequests  set elrq_approvedby=@aphr,elrq_approvedremarks=@rm,elrq_aprvdleaveenddate=now() where empl_id=@id and elrq_index=@eind";
            int index = 0;
            //string grade = null;
            //Gradewiseleavedetails gld = new Gradewiseleavedetails();
            //var r = (dynamic)null;
            //int res;
            try
            {
                using (var conn = edc.CreateConnection())
                {
                    conn.Open();
                    log.LogInfo("Leave Request Approved by Respective HR and update in database");
                    index = conn.ExecuteScalar<int>(query1, new { @id = ur.Id });
                    //grade = conn.ExecuteScalar<string>(query2, new { @id = ur.Id });
                    //r = conn.ExecuteReader(query3, new { @grd = grade });
                    int nor = conn.Execute(query4, new { @id = ur.Id, @aphr=ur.Approved_HrId, @rm=ur.Remarks, @eind=index });
                    if (nor == 1)
                    {
                        return "Approved";
                    }
                    else
                    {
                        return "Not Approved";
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