using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.Contracts.JobGrdHld;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Repository
{
    public class JobGrdHldRepository : IJobGrdHld
    {
        IJobGrdHld ijgh;
        ILoggerManager log = null;
        EmployeeDapperContext edc;
        public JobGrdHldRepository(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }
        public IEnumerable<JobGrdHldEntity> GetJobGrdHlds()
        {
            IEnumerable<JobGrdHldEntity> joggrdh = null;
            try
            {
                log.LogInfo("get the All Job Grade Wise Holidays");
                var query = "select *from JobGradeWiseHolidays";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All Job Grade Wise Holidays from repository");
                    joggrdh = (List<JobGrdHldEntity>)conn.Query<JobGrdHldEntity>(query);
                    return joggrdh.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return joggrdh.ToList();

        }

        public bool AddJobGrdHld(JobGrdHldResource jge)
        {
            string query = "insert into JobGradeWiseHolidays(jbgr_id,jbgr_totalnoh) values(@id,@tdays)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @id = jge.Job_Grade_Id, @tdays = jge.Job_Total_NOH });
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
        public bool EditJobGrdHld(JobGrdHldResource jge)
        {

            string query = "update JobGradeWiseHolidays set jbgr_totalnoh=@tdays where jbgr_id=@id";
            try
            {
                using (var conn = edc.CreateConnection())
                {
                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new {@tdays = jge.Job_Total_NOH, @id = jge.Job_Grade_Id});
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
