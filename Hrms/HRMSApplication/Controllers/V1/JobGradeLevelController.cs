using AutoMapper;
using HRMSApplication.Contracts;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobGradeLevelController : ControllerBase
    {
        ILoggerManager log = null;
        IJGL i;
        IMapper imap;
        public JobGradeLevelController(ILoggerManager log, IJGL i, IMapper im)
        {
            this.log = log;
            this.i = i;
            this.imap = im;
        }

        //method to display all JobGradeWiseLeaves
        [HttpGet]
        public IActionResult GetAllJobGradeWiseLeaves()
        {
            log.LogInfo("Get All Employees");
            return Ok(i.GetAllJobGradeWiseLeaves());
        }
        //method to add JobGradeWiseLeaves
        [HttpPost]
        [Route("/[Controller]/V1/AddJobGradeWiseLeaves")]
        public IActionResult AddJobGradeWiseLeaves(JobGradeLeaves e)
        {
            log.LogInfo(" New Employee is Added");
            return Ok(i.AddJobGradeWiseLeaves(e));
        }

        //method to Update JobGradeWiseLeaves 
        [HttpPut]
        [Route("/[Controller]/V1/UpdateJobGradeWiseLeaves")]
        public IActionResult EditJobGradeWiseLeaves([FromBody] JobGradeLeaves eh)
        {
            log.LogInfo("Employee data is updated");
            return Ok(i.EditJobGradeWiseLeaves(eh));

        }
    }
}
