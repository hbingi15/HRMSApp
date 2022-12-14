namespace HRMSApplication.Models.Resource
{
    public class EmployeeResource
    {
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public int Rmanager_Empl_Id { get; set; }
        public int Hr_Empl_Id { get; set; }
        public string Jbgr_Id { get; set; }
        //  public string Photo { get; set; }
        public DateTime Joiningdate { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public string OffEmail { get; set; }
        public string PersonalEmail { get; set; }
        public long Mobile { get; set; }
        public string AlternativeEmail { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedUser { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string Employee_status { get; set; }
        

    }
}
