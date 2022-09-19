using HRMSApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IInductionRepo
    {
        public IEnumerable<InductionEntity> AllInductions();
        public IActionResult CreateInduction(InductionEntity i);
    }
}
