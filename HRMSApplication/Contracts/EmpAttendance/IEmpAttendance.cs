using HRMSApplication.Models.Entity.EmpAttendance;

namespace HRMSApplication.Contracts.EmpAttendance
{
    public interface IEmpAttendance
    {
        public bool EmployeePunchIn(PunchIn pi);
        public bool EmployeePunchOut(PunchOut po);
        public int CalculateDayAttendance(DayAttendanceEntity da);
        public MonthAttendanceEntity CalculateMonthAttendance(DayAttendanceEntity da);
        public List<AllEmpAtnd> AllEmployeeAttendance();

        public List<AllEmpAtnd> AllEmployeeAttendancebyMonth(MothAttendance dt);
    }
}
