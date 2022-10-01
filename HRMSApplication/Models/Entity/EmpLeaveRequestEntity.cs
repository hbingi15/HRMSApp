namespace HRMSApplication.Models.Entity
{
    public class EmpLeaveRequestEntity
    {
        public int empl_id { get; set; }
        public int elrq_index { get; set; }
        public DateTime elrq_date { get; set; }
        public string elrq_leavetype { get; set; }
        public string elrq_reason { get; set; }
        public DateTime elrq_leavestdate { get; set; }
        public DateTime elrq_leaveenddate { get; set; }
        public int elrq_approvedby { get; set; }
        public string elrq_approvedremarks { get; set; }
        public DateTime elrq_aprvdleavestdate { get; set; }
        public DateTime elrq_aprvdleaveenddate { get; set; }
    }
}