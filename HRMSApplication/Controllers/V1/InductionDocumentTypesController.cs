using AutoMapper;
using HRMSApplication.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    public class InductionDocumentTypesController : ControllerBase
    {
        // define the mapper

        ILoggerManager log = null;
        IInductionDocumentTypes idt;
        IMapper imap;

        public InductionDocumentTypesController(ILoggerManager log, IInductionDocumentTypes idt, IMapper imap)
        {
            this.log = log;
            this.idt = idt;
            this.imap = imap;
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/InductionDocumentTypes")]
        public async Task<IActionResult> GetAllInductionDocumentTypes()
        {
            log.LogInfo("Get All GetInductionDocumentType");
            return Ok(idt.GetAllInductionDocumentTypes());

        }

    }
}
