using AutoMapper;
using HRMSApplication.Contracts;
using HRMSApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.AdminEmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminEmployeeController : ControllerBase
    {
        // define the mapper
        public readonly IMapper _mapper;
        ILoggerManager log = null;
        IAdminEmployee iemp;

        public AdminEmployeeController(ILoggerManager log, IAdminEmployee iemp)
        {
            this.log = log;
            this.iemp = iemp;
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllEmployees")]
        public async Task<IEnumerable<EmployeeEntity>> GetAllEmployees()
        {
            log.LogInfo("Get All Employees");
            return await iemp.GetAllEmployees();
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
        public IActionResult EditEmployee([FromForm] AdminEditEmployee empId)
        {
            log.LogInfo("Employee data is updated");
            return Ok(iemp.EditEmployee(empId));

        }


        //method to delete Employee
        [HttpPatch]
        [Route("/[Controller]/V1/DeleteEmployees")]
        public IActionResult DeleteEmployee([FromBody] string empId)
        {
            log.LogInfo("Existing Employee is Delete ");

            return Ok(iemp.DeleteEmployee(empId));

        }
    }
}
