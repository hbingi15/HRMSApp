using AutoMapper;
using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Repository
{
    public class CandidateRepo : ICandidate
    {
        CandidateDapperContext cdc=null;
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

        /*public IActionResult CreateEmployeeOfferLetter(ECEntity eop)
        {
            using (var conn = cdc.CreateConnection())
            {
                var query = "insert into EmploymentOffers(eofr_ref_id,eofr_cand_id,eofr_offerdat,eofr_offeredjob,eofr_reportingdate,eofr_hrmobileno,eofr_hremail,eofr_status)values(@eofr_ref_id,@eofr_cand_id,@eofr_offerdat,@eofr_offeredjob,@eofr_reportingdate,@eofr_hrmobileno,@eofr_hremail,@eofr_status) returning eofr_cand_id;";
                int eofr_id = conn.QueryFirstOrDefault<int>(query, eop);


                foreach (var candidate in eop.candidates)
                {
                    string qry = "insert into Candidates(cand_firstname,cand_middlename,cand_lastname,cand_rdate,cand_gender,cand_dob,cand_email,cand_mobile,cand_address)Values (@cand_firstname,@cand_middlename,@cand_lastname,@cand_rdate,@cand_gender,@cand_dob,@cand_email,@cand_mobile,@cand_address);";
                    int count = conn.Execute(qry, new { @cand_firstname = candidate.cand_firstname, @cand_middlename = candidate.cand_middlename, @cand_lastname = candidate.cand_lastname, @cand_rdate = candidate.cand_rdate, @cand_gender = candidate.cand_gender, @cand_dob = candidate.cand_dob, @cand_email = candidate.cand_email, @cand_mobile = candidate.cand_mobile, @cand_address = candidate.cand_address });
                }
            }
            return (IActionResult)eop;
        }
*/
        public IEnumerable<CandidatesEntity> GetAllCandidates()
        {
            IEnumerable<CandidatesEntity> candidates1 = null;
            try
            {
                log.LogInfo("get the All Candidates");
                var query = "SELECT * from Candidates";
                using (var conn = cdc.CreateConnection())
                {
                    log.LogInfo("Get All Candidate from repository");
                    candidates1 = (List<CandidatesEntity>)conn.Query<CandidatesEntity>(query);
                    return candidates1.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return candidates1.ToList();

        }


        public bool AddCandidate(CandidatesEntity c)
        {
            string query = "insert into Candidates(cand_id,cand_firstname,cand_middlename,cand_lastname,cand_rdate,cand_gender,cand_dob,cand_email,cand_mobile,cand_address,cand_status)Values (@cand_id,@fnm,@mn,@cand_lastname,@cand_rdate,@cand_gender,@cand_dob,@cand_email,@cand_mobile,@cand_address,@cand_status)";
            try
            {
                using (var conn = cdc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @cand_id=c.cand_id, @fnm = c.cand_firstname, @mn = c.cand_middlename, @cand_lastname = c.cand_lastname, @cand_rdate = c.cand_rdate, @cand_gender = c.cand_gender, @cand_dob = c.cand_dob , @cand_email =c.cand_email, @cand_mobile = c.cand_mobile, @cand_address =c.cand_address ,@cand_status =c.cand_status });
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
        //used to update the Candidate
        public bool EditCandidate(EditCandidate c)
        {
            using (var conn = cdc.CreateConnection())
            {
                var str = c;
                conn.Open();
                log.LogInfo("update the employee function");
                int nor = conn.Execute("update Candidates set cand_email=@cand_email,cand_mobile=@cand_mobile,cand_address=@cand_address,cand_status=@cand_status where cand_id=@cand_id", new { cand_id = c.cand_id, cand_email = c.cand_email, cand_mobile = c.cand_mobile, cand_address = c.cand_address, cand_status =c.cand_status });

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
