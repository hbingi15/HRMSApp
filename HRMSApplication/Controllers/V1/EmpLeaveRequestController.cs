using HRMSApplication.Contracts.EmpAttendance;
using HRMSApplication.Contracts;
using HRMSApplication.Models.Resource;
using Microsoft.AspNetCore.Mvc;
using HRMSApplication.Models.Entity;
using AutoMapper;

namespace HRMSApplication.Controllers.V1
{
    public class EmpLeaveRequestController : ControllerBase
    {
        IEmpLeaveRequest ielr;
        ILoggerManager log = null;
        IMapper imap;
        public EmpLeaveRequestController(ILoggerManager log, IEmpLeaveRequest ielr, IMapper im)
        {
            this.log = log;
            this.ielr = ielr;
            this.imap = im;
        }
        [HttpGet]
        [Route("/[Controller]/V1/AllEmployeeRequest")]
        public IActionResult GetAllEmployeeRequest()
        {
            log.LogInfo("Get All EmployeeRequest");
            return Ok(imap.Map<List<EmpLeaveRequestEntity>>(ielr.GetAllEmployeeRequest()));

        }
        //method to add EmployeeLeaveRequest
        [HttpPost]
        [Route("/[Controller]/V1/AddEmployeeLeaveRequest")]
        public IActionResult AddEmployeeLeaveRequest([FromBody] EmpLeaveRequestEntity e)
        {
            log.LogInfo(" New EmployeeLeaveRequest is Added");
            return Ok(ielr.AddEmployeeLeaveRequest(e));

        }
        //---------------Request for leave-------------
        [HttpPost]
        [Route("/[Controller]/V1/ApplyLeaveRequest")]
        public IActionResult ApplyLeaveRequest([FromBody] LeaveRequestInput el)
        {
            log.LogInfo("Request for leave");
            return Ok(ielr.ApplyLeaveRequest(el));

        }

        //--------------Leave Request Approved by Respective HR-------------
        [HttpPost]
        [Route("/[Controller]/V1/ApprovedByHr")]
        public IActionResult ApprovedByHr([FromBody] UpdateRequestInput ur)
        {
            log.LogInfo("Leave Request Approved by Respective HR");
            return Ok(ielr.ApprovedByHr(ur));

        }

    }
}