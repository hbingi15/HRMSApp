namespace HRMSApplication.Models.Entity
{
    public class EmpOptedLeavesEntity
    {
        public int empl_id { get; set; }
        public int year_id { get; set; }
        public DateTime eolv_date { get; set; }
        public string eolv_leavetype { get; set; }
    }
}