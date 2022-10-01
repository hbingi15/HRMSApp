using HRMSApplication.Models.Entity;

namespace HRMSApplication.Contracts
{
    public interface IEmpOptedLeaves
    {
        public IEnumerable<EmpOptedLeavesEntity> GetAllEmpOptedLeaves();
        public bool AddEmpOptedLeave(EmpOptedLeavesEntity e);
    }
}