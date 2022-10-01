using AutoMapper;
using HRMSApplication.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Controllers.V1
{
    public class EmployeeOfferDocumentsController : Controller
    {
        ILoggerManager log = null;
        IEmployeeOfferDocuments iemp;
        IMapper imap;

        public EmployeeOfferDocumentsController(ILoggerManager log, IEmployeeOfferDocuments iemp, IMapper imap)
        {
            this.log = log;
            this.iemp = iemp;
            this.imap = imap;
        }

        //method to get the All Employees
        [HttpGet]
        [Route("/[Controller]/V1/GetAllEmployeeOfferDocuments")]
        public async Task<IActionResult> GetAllEmployeeOfferDocuments()
        {
            log.LogInfo("Get All Employees");
            return Ok(iemp.GetAllEmployeeOfferDocuments());

        }
    }
}
