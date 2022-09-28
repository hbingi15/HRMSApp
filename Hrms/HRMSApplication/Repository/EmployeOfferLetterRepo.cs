using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;

namespace HRMSApplication.Repository
{
    public class EmployeOfferLetterRepo : IEmployOfferLetter
    {
       
        CandidateDapperContext cdc = null;
        ILoggerManager log = null;

        public EmployeOfferLetterRepo(CandidateDapperContext cdc, ILoggerManager log)
        {
            this.cdc = cdc;
            this.log = log;
        }


        //method to get the All Employees
        public IEnumerable<ECEntity> GetAllEmployeeOffers()
        {
            IEnumerable<ECEntity> employeesOffer = null;
            try
            {
                log.LogInfo("get the All Employees");
                var query = "select * from employmentoffers";
                using (var conn = cdc.CreateConnection())
                {
                    log.LogInfo("Get All employmentoffers from repository");
                    employeesOffer = (List<ECEntity>)conn.Query<ECEntity>(query);
                    return employeesOffer.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return employeesOffer.ToList();

        }



        public bool AddEmployeeOfferLetter(ECEntity e)
        {
            string query = "insert into EmploymentOffers(eofr_ref_id,eofr_cand_id,eofr_offerdat,eofr_offeredjob,eofr_reportingdate,eofr_status)values(@eofr_ref_id,@eofr_cand_id,@eofr_offerdat,@eofr_offeredjob,@eofr_reportingdate,@eofr_status)";
            try
            {
                using (var conn = cdc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @eofr_ref_id = e.eofr_ref_id, @eofr_cand_id = e.eofr_cand_id, @eofr_offerdat = e.eofr_offerdat, @eofr_offeredjob = e.eofr_offeredjob, @eofr_reportingdate = e.eofr_reportingdate, @eofr_status = e.eofr_status });
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

