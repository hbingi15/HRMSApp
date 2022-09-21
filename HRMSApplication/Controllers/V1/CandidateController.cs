using AutoMapper;
using HRMSApplication.Contracts;
using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    public class CandidateController : ControllerBase
    {
        // define the mapper

        ILoggerManager log = null;
        ICandidate ic;
        IMapper imap;

        public CandidateController(ILoggerManager log,ICandidate ic,IMapper im)
        {
            this.log = log;
            this.ic = ic;
            this.imap = im;
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/AllCandidateOfferLetters")]
        public IActionResult GetAllCandidateOfferL()
        {
            log.LogInfo("Get All Candidates");
         // return Ok(imap.Map<List<EOCandidateReource>>(ic.GetAllCandidateOfferL()));
            return Ok(ic.GetAllCandidateOfferL());

        }

        [HttpGet]
        [Route("/[Controller]/V1/AllCandidates")]
        public IActionResult GetAllCandidates()
        {
            log.LogInfo("Get All Candidates");
            // return Ok(imap.Map<List<EOCandidateReource>>(ic.GetAllCandidateOfferL()));
            return Ok(ic.GetAllCandidates());

        }


        [HttpPost]
        [Route("/[Controller]/V1/AddCandidate")]
        public IActionResult AddCandidate([FromBody]CandidatesEntity e)
        {
            log.LogInfo("Add Employee OfferLetter");
            // return Ok(imap.Map<List<CandidateResource>>(ic.AddCandidate(e)));
            return Ok((ic.AddCandidate(e)));

        }

        //method to update Employee
        [HttpPut]
        [Route("/[Controller]/V1/UpdateCandidate")]
        public IActionResult EditCandidate([FromBody] EditCandidate c)
        {
            log.LogInfo("Employee data is updated");
            return Ok(ic.EditCandidate(c));

        }
    }
}
