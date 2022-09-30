using HRMSApplication.Contracts;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HRMSApplication.Models.Resource;
using HRMSApplication.Profie;
using Microsoft.AspNetCore.Authorization;

namespace HRMSApplication.Controllers.EmployeeController
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ILoggerManager log = null;
        IEmployee iemp;
        IMapper imap;

        public EmployeeController(ILoggerManager log, IEmployee iemp,IMapper im)
        {
            this.log = log;
            this.iemp = iemp;
            this.imap = im;
        }



        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllEmployees")]
        public IActionResult GetAllEmployees()
        {
            log.LogInfo("Get All Employees");
            return  Ok(imap.Map<List<EmployeeResource>>(iemp.GetAllEmployees()));

        }


        //method to update Employee
        [HttpPut]
        [Route("/[Controller]/V1/UpdateEmployee")]
        public IActionResult EditEmployee([FromBody] EditEmployee empId)
        {
            log.LogInfo("Employee data is updated");
            return Ok(imap.Map<List<EmployeeResource>>(iemp.EditEmployee(empId)));

        }

    }
}
