using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;

namespace HRMSApplication.Repository
{
    public class InductionDocumentTypesRepo : IInductionDocumentTypes
    {
        CandidateDapperContext cdc = null;
        ILoggerManager log = null;

        public InductionDocumentTypesRepo(CandidateDapperContext cdc, ILoggerManager log)
        {
            this.cdc = cdc;
            this.log = log;

        }
        //method to get the All Employees
        public async Task<IEnumerable<InductionDocumentType>> GetAllInductionDocumentTypes()
        {
            IEnumerable<InductionDocumentType> eod = null;
            try
            {
                log.LogInfo("get the All Candidates");
                var query = "select * from InductionDocumentTypes";
                using (var conn = cdc.CreateConnection())
                {
                    log.LogInfo("Get All Candidate offer letters from repository");
                    eod = (List<InductionDocumentType>)conn.Query<InductionDocumentType>(query);
                    return eod.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return eod.ToList();

        }

    }
}
