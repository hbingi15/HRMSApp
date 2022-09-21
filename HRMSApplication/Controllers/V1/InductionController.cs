using HRMSApplication.Contracts;
using HRMSApplication.Models;
using HRMSApplication.Models.Entity;
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
        public async Task<IActionResult> AllInduction()
        {
            log.LogInfo("Get All Inductions");
            return Ok(id.AllInduction());
        }

        //method to create the  Inductions
        [HttpPost]
        [Route("/[Controller]/V1/AddInduction")]
        public async Task<IActionResult> AddInduction([FromBody]InductionEntity i)
        {
            log.LogInfo("Add Induction");
            return Ok(id.AddInduction(i)); 
        }

        public void FileUpload([FromForm]Files files)
        {
            log.LogInfo("Add Files");
            using var memoryStream = new MemoryStream();
            files.file1.CopyToAsync(memoryStream);
            var a = memoryStream.ToArray();
            string s = Convert.ToBase64String(a);
        }

    }
}
