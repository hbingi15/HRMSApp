namespace HRMSApplication.Models.Entity.EmpAttendance
{
    public class AllEmpAtnd
    {
        //public int Employee_Id { get; set; }
        //public int[] Attendance { get; set; }

        public int empl_id { get; set; }
        public int empl_pindex { get; set; }
        public DateTime eatn_punch_in { get; set; }
        public DateTime Punch_Out { get; set; }
        public string eatn_punchsystem { get; set; }

    }
}
