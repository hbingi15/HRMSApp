using HRMSApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IInductionRepo
    {
        public IEnumerable<InductionEntity> AllInduction();
        public bool AddInduction(InductionEntity e);
        //public bool EmployeeInductionDocuments(EmpInductionDocEntity i);
    }
}
