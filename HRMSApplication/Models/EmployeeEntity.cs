namespace HRMSApplication.Models
{
    public class EmployeeEntity
    {
        //public int empl_id { get; set; }
        public string empl_firstname { get; set; }
        public string empl_lastname { get; set; }
        public string empl_surname { get; set; }
        public string empl_empid { get; set; }
        //public ByteArrayContent empl_photo { get; set; }
        public DateTime empl_joindate { get; set; }
        public DateTime empl_dob { get; set; }
        public string empl_designation { get; set; }
        public string empl_offemail { get; set; }
        public string empl_pemail { get; set; }
        public Int64 empl_mobile { get; set; }
        public string empl_altemail { get; set; }
        public string empl_bloodgroup { get; set; }
        public char empl_gender { get; set; }
        public string empl_address { get; set; }
        public string empl_fatherName { get; set; }
        public string Employee_status { get; set; }
        public DateTime empl_lastUpdatedDate { get; set; }
        public string empl_lastUpdatedUser { get; set; }


    }
   
}

