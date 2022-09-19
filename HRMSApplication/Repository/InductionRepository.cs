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
                log.LogInfo("get the All Inductions");
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
        public bool AddInduction(InductionEntity c)
        {
            string query = "insert into Candidates(cand_firstname,cand_middlename,cand_lastname,cand_rdate,cand_gender,cand_dob,cand_email,cand_mobile,cand_address,cand_status)Values (@fnm,@mn,@cand_lastname,@cand_rdate,@cand_gender,@cand_dob,@cand_email,@cand_mobile,@cand_address,@cand_status)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @fnm = c.cand_firstname, @mn = c.cand_middlename, @cand_lastname = c.cand_lastname, @cand_rdate = c.cand_rdate, @cand_gender = c.cand_gender, @cand_dob = c.cand_dob, @cand_email = c.cand_email, @cand_mobile = c.cand_mobile, @cand_address = c.cand_address, @cand_status = c.cand_status });
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
                throw null;
            }

        }
    }
}
