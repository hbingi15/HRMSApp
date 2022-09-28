using HRMSApplication.Models;
using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IInductionRepo
    {
        public IEnumerable<InductionEntity> AllInduction();
        public bool AddInduction(InductionEntity e);
        //public bool EmployeeInductionDocuments(EmpInductionDocEntity i);
        //public bool AddInductionDocuments(EmpInductionDocEntity id);
    }
}
