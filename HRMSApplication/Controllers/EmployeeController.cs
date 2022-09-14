﻿using HRMSApplication.Contracts;
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
        public List<Employee> GetAllEmployees()
        {
            log.LogInfo("Get All PurchaseOrders");
            return iemp.GetAllEmployees();
        }
    }
}
