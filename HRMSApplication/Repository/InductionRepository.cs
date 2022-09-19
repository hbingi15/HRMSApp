using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models;

namespace HRMSApplication.Repository
{
    public class InductionRepository : IInductionRepo
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;

        public InductionRepository(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }

        //method to get the All Inductions Done
        public IEnumerable<InductionEntity> AllInductions()
        {
            IEnumerable<InductionEntity> induction = null;
            try
            {
                log.LogInfo("get the All Employees");
                var query = "SELECT * FROM EmploymentOffers INNER JOIN Inductions ON EmploymentOffers.EOFR_id=Inductions.indc_emof_id INNER JOIN Candidates ON EmploymentOffers.eofr_cand_id =Candidates.cand_id";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All inductions from repository");
                    induction = (List<InductionEntity>)conn.Query<InductionEntity>(query);
                    return induction.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return induction.ToList();

        }
    }
}
