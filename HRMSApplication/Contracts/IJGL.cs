using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IJGL
    {
        public IEnumerable<JobGradeLeaves> GetAllJobGradeWiseLeaves();
        public bool AddJobGradeWiseLeaves(JobGradeLeaves e);
        public bool EditJobGradeWiseLeaves(JobGradeLeaves eh);
    }
}
