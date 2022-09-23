using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Models;

namespace HRMSApplication.Repository
{
    public class UserRepository : IUser
    {
        EmployeeDapperContext edc;
        ILoggerManager log = null;
        public UserRepository(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }

        public bool AddUser(UserInput u,string id)
        {
            string query = "insert into Employees(empl_firstname, empl_lastname,empl_joindate, empl_mobile,userid) Values(@fnm,@lnm,@jdt,@mbl,@id)";
            long mbnumber = Int64.Parse(u.PhoneNumber);
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @fnm = u.FirstName, @lnm = u.LastName, @jdt = u.JoinDate, @mbl = mbnumber,@id=id});
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
