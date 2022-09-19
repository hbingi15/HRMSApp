using HRMSApplication.Contracts;
using HRMSApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    public class InductionController : ControllerBase
    {
        ILoggerManager log = null;
        IInductionRepo id;

        public InductionController(ILoggerManager log, IInductionRepo id)
        {
            this.log = log;
            this.id = id;
        }
        //method to get the All Inductions
        [HttpGet]
        [Route("/[Controller]/V1/AllInductions")]
        public async Task<IActionResult> AllInductions()
        {
            log.LogInfo("Get All Inductions");
            return Ok(id.AllInductions());
        }

        //method to create the  Inductions
        [HttpPost]
        [Route("/[Controller]/V1/CreateInduction")]
        public IActionResult CreateInduction(InductionEntity i)
        {
            log.LogInfo("Create Induction");
            return (IActionResult)id.CreateInduction(i);
        }

    }
}
