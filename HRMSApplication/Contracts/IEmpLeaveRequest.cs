using HRMSApplication.Models.Entity;

namespace HRMSApplication.Contracts
{
    public interface IEmpLeaveRequest
    {
        public IEnumerable<EmpLeaveRequestEntity> GetAllEmployeeRequest();
        public bool AddEmployeeLeaveRequest(EmpLeaveRequestEntity e);
    }
}