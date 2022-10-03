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
            string query = "insert into Employees(empl_firstname,empl_lastname,empl_surname,empl_jondate,empl_dob,empl_designation,empl_pemail,empl_altemail,empl_mobile,empl_address,empl_fathername,empl_gender,empl_bloodgroup,empl_rmanager_empl_id,empl_hr_empl_id,empl_jbgr_id,empl_offemail,empl_status,userid) Values(@fnm,@lnm,@snm,@jdt,@db,@des,@pem,@alemail,@mbl,@add,@ftnm,@gn,@bgrp,@rm,@hr,@jbgr,@offem,'active',@id)";
            long mbnumber = Int64.Parse(u.PhoneNumber);
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("add new employee function");
                    int nor = conn.Execute(query, new { @fnm = u.FirstName,@lnm = u.LastName,@snm=u.SurName,@jdt = u.JoinDate,@db=u.DOB,@des=u.Designation,@pem=u.PersonalEmail,@alemail=u.AltEmail,@mbl = mbnumber,@add=u.Address,@ftnm=u.FatherName,@gn=u.Gender, @bgrp=u.BloodGroup, @rm=u.Rmanager_Id, @hr=u.HR_Id, @jbgr=u.JobGrade_Id,@offem=u.OffEmail,@id =id});
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
