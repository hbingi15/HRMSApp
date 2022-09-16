using HRMSApplication.Contracts;
using NLog;
using HRMSApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.EmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllerv2 : ControllerBase
    { 

        ILoggerManager log = null;
        IEmployee iemp;
    
        public EmployeeControllerv2(ILoggerManager log, IEmployee iemp)
        {
            this.log = log;
            this.iemp = iemp;
        }
        
        
        
        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V2/AllEmployees")]
        public IEnumerable<EmployeeEntity> GetAllEmployees()
        {
            log.LogInfo("Get All Employees");
            return iemp.GetAllEmployees();
        }

    }
}

