namespace HRMSApplication.Models.Entity.EmpAttendance
{
    public class PunchIn
    {
        public int empl_id { get; set; }
        public int empl_pindex { get; set; }
        public DateTime eatn_punch_in { get; set; }
        public string eatn_punchsystem { get; set; }

    }
}
