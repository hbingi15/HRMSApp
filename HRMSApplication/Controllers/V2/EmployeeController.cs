﻿using HRMSApplication.Contracts;

using HRMSApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.EmployeeController
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

        //method to add Employee
        [HttpPost]
        [Route("/[Controller]/V2/AddEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeEntity e)
        {
            log.LogInfo(" New Employee is Added");
            return Ok(iemp.AddEmployee(e));

        }

        //method to delete Employee
        [HttpPatch]
        [Route("/[Controller]/V2/DeleteEmployees")]
        public IActionResult DeleteEmployee([FromBody] string empId)
        {
            log.LogInfo("Existing Employee is Delete ");

            return Ok(iemp.DeleteEmployee(empId));

        }

        //method to update Employee
        [HttpPut]
        [Route("/[Controller]/V2/UpdateEmployee")]
        public IActionResult EditEmployee([FromForm] EditEmployee empId)
        {
            log.LogInfo("Employee data is updated");
            return Ok(iemp.EditEmployee(empId));

        }

    }
}