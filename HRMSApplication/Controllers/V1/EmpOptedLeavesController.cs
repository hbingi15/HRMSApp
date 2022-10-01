using AutoMapper;
using HRMSApplication.Contracts;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    public class EmpOptedLeavesController : ControllerBase
    {

        ILoggerManager log = null;
        IEmpOptedLeaves iemp;
        IMapper imap;

        public EmpOptedLeavesController(ILoggerManager log, IEmpOptedLeaves iemp, IMapper im)
        {
            this.log = log;
            this.iemp = iemp;
            this.imap = im;
        }



        //method to get the All Employees Opted Leaves
        [HttpGet]
        [Route("/[Controller]/V1/AllEmpOptedLeaves")]
        public IActionResult GetAllEmpOptedLeaves()
        {
            log.LogInfo("Get All Employees Opted Leaves");
            return Ok(imap.Map<List<EmpOptedLeavesEntity>>(iemp.GetAllEmpOptedLeaves()));

        }
        //method to add Employee Opted Leave
        [HttpPost]
        [Route("/[Controller]/V1/AddEmployeeOptedLeave")]
        public IActionResult AddEmpOptedLeave([FromBody] EmpOptedLeavesEntity e)
        {
            log.LogInfo(" New EmployeeLeaveRequest is Added");
            return Ok(iemp.AddEmpOptedLeave(e));

        }


    }
}