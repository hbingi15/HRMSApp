using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IEnumerable<InductionEntity> AllInductions()
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


        //creating induction 
        public IActionResult CreateInduction(InductionEntity i)
        {
            IEnumerable<InductionEntity> induction = null;
            try
            {
                log.LogInfo("Add the new Induction");
                var query = "call InsertMultipleValues(@eofdate,@eofjob,@eofrepodate,@cfirst,@cmiddle,@clast,@cgender,@cemail,@caddress,@idate)";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Create new Induction into repository");
                    int nor = conn.Execute(query, new { @eofdate = i.eofr_offerdate, @eofjob = i.eofr_offeredjob, @eofrepodate = i.eofr_reportingdate, @cfirst = i.cand_firstname, @cmiddle = i.cand_middlename, @clast = i.cand_lastname, @cgender = i.cand_gender, @cemail = i.cand_email, @caddress = i.cand_address, @idate = i.indc_date });
                    //induction = (List<InductionEntity>)conn.Query<InductionEntity>(query);
                    //return induction.ToList();
                    if (nor == 1)
                    {
                        return (IActionResult)i;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
