﻿namespace HRMSApplication.EntityModels
{
    public class Employee
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string EmpId { get; set; }
       //  public string Photo { get; set; }
        public DateTime Joiningdate { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public string OffEmail { get; set; }
        public string PersonalEmail { get; set; }
        public Int64 Mobile { get; set; }
        public string AlternativeEmail { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string empl_fathername { get; set; }
        public string Employee_status { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedUser { get; set; }

    }
}
