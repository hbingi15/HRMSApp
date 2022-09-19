using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models;

namespace HRMSApplication.Repository
{
    public class InductionRepository : IInductionRepo
    {
        InductionDapperContext edc;
        ILoggerManager log = null;

        public InductionRepository(InductionDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }

        //method to get the All Inductions Done
        
        public async Task<IEnumerable<InductionEntity>> AllInductions()

        {
            IEnumerable<InductionEntity> inductions = null;
            try
            {
                log.LogInfo("get the All Candidates");
                var query = "SELECT * FROM EmploymentOffers INNER JOIN Inductions ON EmploymentOffers.EOFR_id=Inductions.indc_emof_id INNER JOIN Candidates ON EmploymentOffers.eofr_cand_id =Candidates.cand_id";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get inductions");
                    inductions = (List<InductionEntity>)conn.Query<InductionEntity>(query);
                    return inductions.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return inductions.ToList();

        }
    }
}
