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
            string query = "insert into Employees(empl_firstname, empl_lastname,empl_surname,empl_jondate,empl_dob,empl_designation,empl_pemail,empl_mobile,empl_address,empl_fathername,empl_gender,userid) Values(@fnm,@lnm,@snm,@jdt,@db,@des,@pem,@mbl,@add,@ftnm,@gn,@id)";
            long mbnumber = Int64.Parse(u.PhoneNumber);
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @fnm = u.FirstName,@lnm = u.LastName,@snm=u.SurName,@jdt = u.JoinDate,@db=u.DOB,@des=u.Designation,@pem=u.PersonalEmail,@mbl = mbnumber,@add=u.Address,@ftnm=u.FatherName,@gn=u.Gender,@id=id});
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
