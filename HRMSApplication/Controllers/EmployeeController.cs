using HRMSApplication.Contracts;

using HRMSApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ILoggerManager log = null;
        IEmployee iemp;

        public EmployeeController(ILoggerManager log, IEmployee iemp)
        {
            this.log = log;
            this.iemp = iemp;
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllEmployees")]
        public IEnumerable<EmployeeResource> GetAllEmployees()
        {
            log.LogInfo("Get All Employees");
            return iemp.GetAllEmployees();
        }

        //method to add Employee
        [HttpPost]
        [Route("/[Controller]/V1/AddEmployee")]
        public bool AddEmployee([FromBody]EmployeeResource e)
        {
            log.LogInfo("Add Employee");
            return iemp.AddEmployee(e);

        }

        [HttpPatch]
        [Route("/[Controller]/V1/DeleteEmployees")]
        public bool DeleteEmployee([FromBody] string empId)
        {
            log.LogInfo("Delete Employee");
            
            return iemp.DeleteEmployee(empId);

        }

        [HttpPut]
        [Route("/[Controller]/V1/UpdateEmployee")]
        public bool UpdateEmployee([FromBody] EditEmployee empId)
        {
            log.LogInfo(" Edit Employee");
            return iemp.EditEmployee(empId);

        }
    }
}
