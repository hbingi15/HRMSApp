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
        ILoggerManager log = null;
        IEmployee iemp;

        public AdminEmployeeController(ILoggerManager log, IEmployee iemp)
        {
            this.log = log;
            this.iemp = iemp;
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllEmployees")]
        public IEnumerable<EmployeeEntity> GetAllEmployees()
        {
            log.LogInfo("Get All Employees");
            return iemp.GetAllEmployees();
        }

    }
}
