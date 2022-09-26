using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;

namespace HRMSApplication.Repository
{
    public class JobGradeLRepo : IJGL
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;
        public JobGradeLRepo(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }
        //method to get the All Employees
        public IEnumerable<JobGradeLeaves> GetAllJobGradeWiseLeaves()
        {
            IEnumerable<JobGradeLeaves> j = null;
            try
            {
                log.LogInfo("get the All JobGradeWiseLeaves");
                var query = "select * from JobGradeWiseLeaves";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All JobGradeWiseLeaves from repository");
                    j = (List<JobGradeLeaves>)conn.Query<JobGradeLeaves>(query);
                    return j.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return j.ToList();

        }
        //method to add new JobGradeWiseLeaves
        public bool AddJobGradeWiseLeaves(JobGradeLeaves e)
        {
            string query = "insert into JobGradeWiseLeaves(jbgr_id,jbgr_totalnol,jbgr_nocl,jbgr_nosl,jbgr_nool) Values(@jbgr_id,@jbgr_totalnol,@jbgr_nocl,@jbgr_nosl,@jbgr_nool)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @jbgr_id = e.jbgr_id, @jbgr_totalnol = e.jbgr_totalnol, @jbgr_nocl = e.jbgr_nocl, @jbgr_nosl = e.jbgr_nosl, @jbgr_nool = e.jbgr_nool });
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
        //used to update the JobGradeWiseLeaves
        public bool EditJobGradeWiseLeaves(JobGradeLeaves eh)
        {
            using (var conn = edc.CreateConnection())
            {
                var str = eh;
                conn.Open();
                log.LogInfo("update the  function");
                int nor = conn.Execute("update jobgradewiseleaves set jbgr_totalnol=@jbgr_totalnol,jbgr_nocl=@jbgr_nocl,jbgr_nosl=@jbgr_nosl,jbgr_nool=@jbgr_nool where jbgr_id=@jbgr_id ", new { jbgr_totalnol = eh.jbgr_totalnol, jbgr_nocl = eh.jbgr_nocl, jbgr_nosl =eh.jbgr_nosl, jbgr_nool=eh.jbgr_nool,jbgr_id = eh.jbgr_id });
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
