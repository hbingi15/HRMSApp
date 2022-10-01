using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;

namespace HRMSApplication.Repository
{
    public class EmployeeOfferDocumentRepo : IEmployeeOfferDocuments
    {
        CandidateDapperContext cdc = null;
        ILoggerManager log = null;

        public EmployeeOfferDocumentRepo(CandidateDapperContext cdc, ILoggerManager log)
        {
            this.cdc = cdc;
            this.log = log;

        }
        //method to get the All Employees
        public async Task<IEnumerable<InductionDocumentTypesEntity>> GetAllEmployeeOfferDocuments()

        {
            IEnumerable<InductionDocumentTypesEntity> eod = null;
            try
            {
                log.LogInfo("get the All Candidates");
                var query = "select * from EmploymentOfferDocuments";
                using (var conn = cdc.CreateConnection())
                {
                    log.LogInfo("Get All Candidate offer letters from repository");
                    eod = (List<InductionDocumentTypesEntity>)conn.Query<InductionDocumentTypesEntity>(query);
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
