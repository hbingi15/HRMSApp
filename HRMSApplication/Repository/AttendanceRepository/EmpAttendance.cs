using Dapper;
using HRMSApplication.Contracts;
using HRMSApplication.Contracts.EmpAttendance;
using HRMSApplication.DapperORM;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Entity.EmpAttendance;

namespace HRMSApplication.Repository.AttendanceRepository
{
    public class EmpAttendance : IEmpAttendance
    {
        ILoggerManager log = null;
        EmployeeDapperContext edc;
        IEmpAttendance iea;
        public EmpAttendance(EmployeeDapperContext edc, ILoggerManager log)
        {
            this.edc = edc;
            this.log = log;
        }
        public bool EmployeePunchIn(PunchIn pi)
        {
            string query = "insert into employeeattendance(empl_id,empl_pindex,eatn_punch_in,eatn_punchsystem) values(@eid,@eind,@epin,@pnsys)";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("Update Employee Punch In Timings");
                    int nor = conn.Execute(query, new { @eid = pi.empl_id, @eind = pi.empl_pindex, @epin = pi.eatn_punch_in, @pnsys = pi.eatn_punchsystem });
                    if (nor == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception msg)
            {
                throw msg;
            }
        }
        public bool EmployeePunchOut(PunchOut po)
        {
            string query = "update employeeattendance set eatn_punch_out=@pot where empl_id=@id and empl_pindex=@pind";
            try
            {
                using (var conn = edc.CreateConnection())
                {

                    conn.Open();
                    log.LogInfo("Update Employee Punch Out Timings");
                    int nor = conn.Execute(query, new { @id = po.Id, @pind = po.empl_pindex, @pot = po.Punch_Out });
                    if (nor == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception msg)
            {
                throw msg;
            }
        }

        //--Day Attendance of Particular Employee
        public int CalculateDayAttendance(DayAttendanceEntity da)
        {
            string query = "select * from EmployeeAttendance where empl_id=@id and date_id=@dtid";
            string query1 = "select date_part('hour', @eatn_punch_out::timestamp - @eatn_punch_in::timestamp) from employeeattendance where empl_id=@id and date_id=@dtid";
            // string query2 = "select sum(date_part('hour',eatn_punch_in::timestamp - eatn_punch_out::timestamp)) from EmployeeAttendance where empl_id = " + id;
            int totalhours = 0;
            int punchingHours = 0;
            int tot_hours = 0;
            IEnumerable<DayAttendance> dayattend = null;
            try
            {
                using (var conn = edc.CreateConnection())
                {
                    conn.Open();
                    log.LogInfo("Calculate Day Attendance of Particular Employee");
                    dayattend = (List<DayAttendance>)conn.Query<DayAttendance>(query, new {@id = da.Emp_Id, @dtid = da.day});
                    //totalhours = conn.Execute(query2);

                    foreach (var attendance in dayattend)
                    {
                        punchingHours = conn.ExecuteScalar<int>(query1, new { @eatn_punch_in = attendance.eatn_punch_in, @eatn_punch_out = attendance.eatn_punch_out, @id= da.Emp_Id, @dtid=da.day});
                        totalhours = totalhours + punchingHours;
                        tot_hours = Math.Abs(totalhours);
                    }
                    return tot_hours;

                }
            }
            catch (Exception msg)
            {
                throw msg;
            }
        }
        //overloading CalculateDayAttendance  method
        public int CalculateDayAttendance(int id,DateTime dt)
        {
            string query = "select * from EmployeeAttendance where empl_id=@id and date_id=@dtid";
            string query1 = "select date_part('hour', @eatn_punch_out::timestamp - @eatn_punch_in::timestamp) from employeeattendance where empl_id=@id and date_id=@dtid";
            // string query2 = "select sum(date_part('hour',eatn_punch_in::timestamp - eatn_punch_out::timestamp)) from EmployeeAttendance where empl_id = " + id;
            int totalhours = 0;
            int punchingHours = 0;
            int tot_hours = 0;
            IEnumerable<DayAttendance> dayattend = null;
            try
            {
                using (var conn = edc.CreateConnection())
                {
                    conn.Open();
                    log.LogInfo("Calculate Monthly Attendance of Particular Employee");
                    dayattend = (List<DayAttendance>)conn.Query<DayAttendance>(query, new { @id = id, @dtid = dt });
                    //totalhours = conn.Execute(query2);

                    foreach (var attendance in dayattend)
                    {
                        punchingHours = conn.ExecuteScalar<int>(query1, new { @eatn_punch_in = attendance.eatn_punch_in, @eatn_punch_out = attendance.eatn_punch_out, @id = id, @dtid = dt });
                        totalhours = totalhours + punchingHours;
                        tot_hours = Math.Abs(totalhours);
                    }
                    return tot_hours;

                }
            }
            catch (Exception msg)
            {
                throw msg;
            }
        }
        //--Monthly Attendance of Particular Employee
        public MonthAttendanceEntity CalculateMonthAttendance(DayAttendanceEntity da)
        {

            MonthAttendanceEntity ma = new MonthAttendanceEntity();
            //--Query for getting starting day of given date
            string query1 = "select date_trunc('month',@gdt)";

            //--Query for getting ending day of given date
            string query2 = "SELECT (date_trunc('month', @gdt::date) + interval '1 month' - interval '1 day')::date";
           
            //--Query for getting holidays of given date(month)
            string query3 = " select count(*) from holidays where hday_date>=@st and hday_date<=@et";
           
            DateTime stdt, endt;
            int datattend,i = 0,actual_attendance=0,NoOfHolidays; 
            int[] mon_atd = new int[31];
            //monatd[0] = 2;
            
            try
            {
                using (var conn = edc.CreateConnection())
                {
                    conn.Open();
                    log.LogInfo("Calculate Monthly Attendance of Particular Employee");
                    stdt = conn.ExecuteScalar<DateTime>(query1, new {@gdt=da.day});
                    endt = conn.ExecuteScalar<DateTime>(query2, new { @gdt = da.day });
                    NoOfHolidays = conn.ExecuteScalar<int>(query3, new { @st = stdt,@et=endt });
                    while (stdt < endt)
                    {
                        //--Calling Employee Day attendance
                        datattend = CalculateDayAttendance(da.Emp_Id,stdt);
                        stdt = stdt.AddDays(1);
                        //--Assign Day attendance to array
                        mon_atd[i] = datattend;
                        i++;
                    }
                    log.LogInfo("Calculate Actual Attended days in a given month");
                    for (int at = 0; at < mon_atd.Length; at++)
                    {
                        if (mon_atd[at] != 0)
                        {
                            actual_attendance++;
                        }
                    }
                }
                //
                ma.NoOfDays = i+1;
                ma.NoOfHolidays = NoOfHolidays;
                ma.Actual_Attended_days = actual_attendance;
                ma.Mon_Atd = mon_atd;

            }
            catch (Exception msg)
            {
                throw msg;
            }
            return ma;
        }
    }
}
