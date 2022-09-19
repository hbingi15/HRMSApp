using HRMSApplication.Contracts;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Controllers.EmployeeController
{
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
        public IActionResult EditEmployee([FromForm] EditEmployee empId)
        {
            log.LogInfo("Employee data is updated");
            return Ok(iemp.EditEmployee(empId));

        }

    }
}
