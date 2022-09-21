using Dapper;
using Grpc.Core;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Repository
{
    public class InductionRepository : IInductionRepo
    {
        InductionDapperContext edc;
        ILoggerManager log = null;

        public string emid_document { get; private set; }

        public InductionRepository(InductionDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }

        //method to get the All Inductions Done

        public IEnumerable<InductionEntity> AllInduction()
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
        public bool AddInduction(InductionEntity e)
        {
            string query = "insert into Inductions (indc_id,indc_emof_id,indc_date,indc_processed_ausr_id,indc_status)  values(@indc_id,@indc_emof_id, @indc_date, @indc_processed_ausr_id, @indc_status)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @indc_id = e.indc_id, @indc_emof_id = e.indc_emof_id, @indc_date = e.indc_date, @indc_processed_ausr_id = e.indc_processed_ausr_id, @indc_status = e.indc_status });
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
        public bool AddInductionDocuments(EmpInductionDocEntity id)
        {


            string query = "insert into EmployeeInductionDocuments (empl_ind_id,emid_docindex,emid_idty_id,emid_document,emid_processed_ausr_id,emid_verified)  values (@empl_ind_id,@emid_docindex,@emid_idty_id,@emid_document,@emid_processed_ausr_id,@emid_verified )";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @empl_ind_id = id.@empl_ind_id, @emid_docindex = id.emid_docindex, @emid_idty_id = id.emid_idty_id, @emid_document = id.emid_document, @emid_processed_ausr_id = id.emid_processed_ausr_id, @emid_verified = id.emid_verified });
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
    
