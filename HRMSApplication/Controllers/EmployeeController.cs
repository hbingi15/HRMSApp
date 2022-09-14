using HRMSApplication.Contracts;
using HRMSApplication.EntityModels;
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
        public IEnumerable<Employee> GetAllEmployees()
        {
            log.LogInfo("Get All Employees");
            return iemp.GetAllEmployees();
        }
        //method to add Employess
        [HttpPost]
        [Route("/[Controller]/V1/AddEmployees")]
        public bool AddEmployee([FromBody] Employee e)
        {
            log.LogInfo("Add Employee");
            return iemp.AddEmployee(e);

        }
        /*[Httppatch]
        [Route("/[Controller]/V1/DeleteEmployees")]
        public bool DeleteEmployee([FromBody]Employee e)
        {
            log.LogInfo("Delete Employee");
            
            return iemp.AddEmployee(e);

        }*/
        //[HttpPut]
        //[Route("/[Controller]/V1/UpdateEmployee")]
        //public bool UpdateEmployee([FromBody] EmployeeResource e)
        //{
        //    return iemp.UpdateEmployee(e);

        //}
    }
}
