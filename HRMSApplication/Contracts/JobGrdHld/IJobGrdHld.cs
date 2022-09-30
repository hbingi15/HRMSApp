using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Contracts.JobGrdHld
{
    public interface IJobGrdHld
    {
        public IEnumerable<JobGrdHldEntity> GetJobGrdHlds();
        public bool AddJobGrdHld(JobGrdHldResource jge);
        public bool EditJobGrdHld(JobGrdHldResource jge);
    }
}
