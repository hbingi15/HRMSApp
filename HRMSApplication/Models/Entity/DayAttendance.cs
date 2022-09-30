namespace HRMSApplication.Models.Entity
{
    public class DayAttendance
    {
        public int empl_id { get; set; }
        public int empl_pindex { get; set; }
        public DateTime eatn_punch_in { get; set; }
        public DateTime eatn_punch_out { get; set; }
    }
}
