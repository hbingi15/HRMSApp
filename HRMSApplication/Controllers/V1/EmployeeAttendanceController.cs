using HRMSApplication.Contracts;
using HRMSApplication.Contracts.EmpAttendance;
using HRMSApplication.Models.Entity.EmpAttendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceController : ControllerBase
    {
        IEmpAttendance iea;
        ILoggerManager log = null;
        public EmployeeAttendanceController(ILoggerManager log, IEmpAttendance iea)
        {
            this.log = log;
            this.iea = iea;
        }
        //Update Employee Punch In Timings
        [HttpPost]
        [Route("/[Controller]/V1/EmployeePunchIn")]
        public IActionResult EmployeePunchIn([FromBody]PunchIn pi)
        {
            log.LogInfo("Punch_In Timings");
            return Ok(iea.EmployeePunchIn(pi));
        }

        //Update Employee Punch Out Timings
        [HttpPut]
        [Route("/[Controller]/V1/EmployeePunchOut")]
        public IActionResult EmployeePunchOut([FromBody] PunchOut po)
        {
            log.LogInfo("Punch_Out Timings");
            return Ok(iea.EmployeePunchOut(po));
        }

        //Calculate Day Attendance of given Employee
        [HttpPost]
        [Route("/[Controller]/V1/DayAttendance")]
        public IActionResult CalculateDayAttendance([FromBody] DayAttendanceEntity da)
        {
            log.LogInfo("Calculate Day Attendance");
            return Ok(iea.CalculateDayAttendance(da));
        }

        //Calculate Month Attendance  of given Employee
        [HttpPost]
        [Route("/[Controller]/V1/MonthAttendance")]
        public IActionResult CalculateMonthAttendance([FromBody] DayAttendanceEntity da)
        {
            log.LogInfo("Calculate Month Attendance");
            return Ok(iea.CalculateMonthAttendance(da));
        }
        [HttpGet]
        [Route("/[Controller]/V1/AllEmployeeAttendance")]
        public IActionResult AllEmployeeAttendance()
        {
            return Ok(iea.AllEmployeeAttendance());
        }

        [HttpPost]
        [Route("/[Controller]/V1/AllEmployeeAttendancebyMonth")]
        public IActionResult AllEmployeeAttendancebyMonth(DateTime dt)
        {
            return Ok(iea.AllEmployeeAttendancebyMonth(dt));
        }
    }
}
