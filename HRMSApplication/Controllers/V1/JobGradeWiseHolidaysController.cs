using AutoMapper;
using HRMSApplication.Contracts;
using HRMSApplication.Contracts.JobGrdHld;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobGradeWiseHolidaysController : ControllerBase
    {
        ILoggerManager log = null;
        IJobGrdHld ijgh;
        IMapper imap;
        public JobGradeWiseHolidaysController(ILoggerManager log, IJobGrdHld ijgh, IMapper imap)
        {
            this.log = log;
            this.ijgh = ijgh;
            this.imap= imap;
        }

        //method to get the All JobGrdHlds
        [HttpGet]
        [Route("/[Controller]/V1/GetJobGrdHlds")]
        public IActionResult GetJobGrdHlds()
        {
            log.LogInfo("Get All JobGrdHlds");
            return Ok(imap.Map<List<JobGrdHldResource>>(ijgh.GetJobGrdHlds()));

        }
        //method to Add JobGrdHld
        [HttpPost]
        [Route("/[Controller]/V1/AddJobGrdHld")]
        public IActionResult AddJobGrdHld([FromBody] JobGrdHldResource jge)
        {
            log.LogInfo("Add JobGrdHld");
            return Ok(ijgh.AddJobGrdHld(jge));
        }
        [HttpPut]
        [Route("/[Controller]/V1/EditJobGrdHld")]
        public IActionResult EditJobGrdHld([FromBody] JobGrdHldResource jge)
        {
            log.LogInfo("Edit JobGrdHld");
            return Ok(ijgh.EditJobGrdHld(jge));
        }

    }
}
