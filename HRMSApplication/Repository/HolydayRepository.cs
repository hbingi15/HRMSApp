using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Repository
{
    public class HolydayRepository : IHolyday
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;
        public HolydayRepository(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }
        //method to get the All Employees
        public IEnumerable<HolydayEntity> GetAllHolydays()
        {
            IEnumerable<HolydayEntity> holydays = null;
            try
            {
                log.LogInfo("get the All Holydays");
                var query = "select * from Holidays";
                using (var conn = edc.CreateConnection())
                {
                    log.LogInfo("Get All Holydays from repository");
                    holydays = (List<HolydayEntity>)conn.Query<HolydayEntity>(query);
                    return holydays.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return holydays.ToList();

        }
        //method to add new employee
        public bool AddHolyday(HolydayEntity e)
        {
            string query = "insert into Holidays(year_id,hday_date,hday_title,hday_type) Values(@year_id,@hday_date,@hday_title,@hday_type)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @year_id = e.year_id, @hday_date = e.hday_date, @hday_title = e.hday_title, @hday_type = e.hday_type });
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
        //used to update the holyday
        public bool EditHolyday(EditHolyday eh)
        {
            using (var conn = edc.CreateConnection())
            {
                var str = eh;
                conn.Open();
                log.LogInfo("update the  function");
                int nor = conn.Execute("update Holidays set hday_type=@hday_type  where hday_title=@hday_title", new { hday_title = eh.hday_title, hday_type = eh.hday_type });
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
