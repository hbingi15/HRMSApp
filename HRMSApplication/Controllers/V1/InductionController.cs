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
        [HttpPost]
        [Route("/[Controller]/V1/AInduction")]
        public void Resumecheck([FromForm] EmpInductionDocEntity file)
        {
            log.LogInfo("Add Files");
            using var memoryStream = new MemoryStream();
            file.Resume.CopyToAsync(memoryStream);
            var a = memoryStream.ToArray();
            string s = Convert.ToBase64String(a);
           
        
            log.LogInfo("Add Files");
            using var memoryStream1 = new MemoryStream();
            file.SSCCertificates.CopyToAsync(memoryStream1);
            var a1 = memoryStream1.ToArray();
            string s1 = Convert.ToBase64String(a1);

        
        
            log.LogInfo("Add Files");
            using var memoryStream2 = new MemoryStream();
            file.SSCCertificates.CopyToAsync(memoryStream2);
            var a2 = memoryStream2.ToArray();
            string s2 = Convert.ToBase64String(a2);

        
            log.LogInfo("Add Files");
            using var memoryStream3 = new MemoryStream();
            file.SSCCertificates.CopyToAsync(memoryStream3);
            var a3 = memoryStream3.ToArray();
            string s3 = Convert.ToBase64String(a3);

        }


    }
}
