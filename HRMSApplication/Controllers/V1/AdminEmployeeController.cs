using AutoMapper;
using HRMSApplication.Contracts;
/*using HRMSApplication.EntityModels;*/
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.AdminEmployeeController
{
   
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Employee")]
    public class AdminEmployeeController : ControllerBase
    { 
        // define the mapper
       
        ILoggerManager log = null;
        IAdminEmployee iemp;
        IMapper imap;

        public AdminEmployeeController(ILoggerManager log, IAdminEmployee iemp, IMapper imap)
        {
            this.log = log;
            this.iemp = iemp;
            this.imap = imap;
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            log.LogInfo("Get All Employees");
           return Ok( iemp.GetAllEmployees());
            
        }

        //method to add Employee
        [HttpPost]
        [Route("/[Controller]/V1/AddEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeEntity e)
        {
            log.LogInfo(" New Employee is Added");
            return Ok(iemp.AddEmployee(e));

        }

        //method to update Employee
        [HttpPut]
        [Route("/[Controller]/V1/UpdateEmployee")]
        public IActionResult EditEmployee([FromBody] AdminEditEmployee empId)
        {
            log.LogInfo("Employee data is updated");
            return Ok(iemp.EditEmployee(empId));

        }

        //method to delete Employee
        [HttpPatch]
        [Route("/[Controller]/V1/DeleteEmployees")]
        public IActionResult DeleteEmployee([FromBody] int empId)
        {
            log.LogInfo("Existing Employee is Delete ");

            return Ok(iemp.DeleteEmployee(empId));

        }
        
    }
}
