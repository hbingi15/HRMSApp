using AutoMapper;
using HRMSApplication.Contracts;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolydayController : Controller
    {
        ILoggerManager log = null;
        IHolyday ih;
        IMapper imap;

        public HolydayController(ILoggerManager log, IHolyday ih, IMapper im)
        {
            this.log = log;
            this.ih = ih;
            this.imap = im;
        }
        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllHolydays")]
        public IActionResult GetAllHolydays()
        {
            log.LogInfo("Get All Employees");
            return Ok(ih.GetAllHolydays());
        }

        //method to add Employee
        [HttpPost]
        [Route("/[Controller]/V1/AddHolyday")]
        public IActionResult AddHolyday([FromBody] HolydayEntity e)
        {
            log.LogInfo(" New Employee is Added");
            return Ok(ih.AddHolyday(e));

        }
        //method to update Employee
        [HttpPut]
        [Route("/[Controller]/V1/UpdateHolyday")]
        public IActionResult EditHolyday([FromBody] EditHolyday eh)
        {
            log.LogInfo("Employee data is updated");
            return Ok(ih.EditHolyday(eh));

        }

    }
}
