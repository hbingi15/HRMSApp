using HRMSApplication.Contracts;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeOfferLetterControllerr : ControllerBase
    {
        ILoggerManager log = null;
        IEmployOfferLetter  io;
        public EmployeeOfferLetterControllerr(ILoggerManager log, IEmployOfferLetter io)
        {
            this.log = log;
            this.io = io;
            
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllEmployeeOfferLetter")]
        public IActionResult GetAllEmployeeOffers()
        {
            log.LogInfo("Get All Employees");
            return Ok(io.GetAllEmployeeOffers());
        }


        [HttpPost]
            [Route("/[Controller]/V1/AddEmployeeOfferLetter")]
            public IActionResult AddEmployeeOfferLetter([FromBody]ECEntity e)
            {
                log.LogInfo("Add Employee OfferLetter");
                //return Ok(imap.Map<List<EmployeeOfferResource>>(ic.AddEmployeeOfferLetter(e)));
                return Ok(io.AddEmployeeOfferLetter(e));
            }
        }
}
