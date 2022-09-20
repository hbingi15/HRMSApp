using HRMSApplication.Contracts;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    public class CandidateController : ControllerBase
    {
        // define the mapper

        ILoggerManager log = null;
        ICandidate ic;

        public CandidateController(ILoggerManager log, ICandidate ic)
        {
            this.log = log;
            this.ic = ic;
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllCandidateOfferLetters")]
        public async Task<IActionResult> GetAllCandidateOfferL()
        {
            log.LogInfo("Get All Candidates");
            return Ok(ic.GetAllCandidateOfferL());


        }
        

        [HttpPost]
        [Route("/[Controller]/V1/AddEmployeeOfferLetter")]
        public IActionResult AddEmployeeOfferLetter([FromBody]ECEntity e)
        {
            log.LogInfo("Add Employee OfferLetter");
            return Ok(ic.AddEmployeeOfferLetter(e));
        }

        [HttpPost]
        [Route("/[Controller]/V1/AddCandidate")]
        public IActionResult AddCandidate([FromBody]CandidatesEntity e)
        {
            log.LogInfo("Add Employee OfferLetter");
            return Ok(ic.AddCandidate(e));
        }
    }
}
