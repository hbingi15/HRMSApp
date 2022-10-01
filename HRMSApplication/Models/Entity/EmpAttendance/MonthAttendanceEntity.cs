namespace HRMSApplication.Models.Entity.EmpAttendance
{
    public class MonthAttendanceEntity
    {
        public int NoOfDays { get; set; }
        public int NoOfHolidays { get; set; }
        public int Actual_Attended_days { get; set; }
        public int[] Mon_Atd  { get; set; }
    }
}
