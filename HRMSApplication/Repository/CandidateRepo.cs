using AutoMapper;
using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;

namespace HRMSApplication.Repository
{
    public class CandidateRepo : ICandidate
    {
        CandidateDapperContext cdc;
        ILoggerManager log = null;
       
        public CandidateRepo(CandidateDapperContext cdc, ILoggerManager log)
        {
            this.cdc = cdc;
            this.log = log;
            
        }
        //method to get the All Employees
        public async Task<IEnumerable<EOCandidateEntity>> GetAllCandidateOfferL()
        
        {
            IEnumerable<EOCandidateEntity> candidates = null;
            try
            {
                log.LogInfo("get the All Candidates");
                var query = "SELECT employmentoffers.eofr_id,eofr_ref_id,eofr_cand_id,eofr_offerdat,eofr_offeredjob,eofr_reportingdate,eofr_status,cand_id,cand_firstname,cand_middlename,cand_lastname,cand_rdate,cand_gender,cand_dob,cand_email,cand_mobile,cand_address FROM employmentoffers INNER JOIN Candidates ON Candidates.cand_id = employmentoffers.eofr_cand_id ORDER BY cand_address ";
                using (var conn = cdc.CreateConnection())
                {
                    log.LogInfo("Get All Candidate offer letters from repository");
                    candidates = (List<EOCandidateEntity>)conn.Query<EOCandidateEntity>(query);
                    return candidates.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return candidates.ToList();

        }
        
    }
}
