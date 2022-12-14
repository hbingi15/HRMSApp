using HRMSApplication.Models.Entity;
using HRMSApplication.Models.Resource;

namespace HRMSApplication.Contracts
{
    public interface IEmpLeaveRequest
    {
        public IEnumerable<EmpLeaveRequestEntity> GetAllEmployeeRequest();
        public bool AddEmployeeLeaveRequest(EmpLeaveRequestEntity e);
        public bool ApplyLeaveRequest(LeaveRequestInput el);
        public string ApprovedByHr(UpdateRequestInput ur);
        public List<EmpLeaveRequestEntity> EmployeeApprovedLeaves(EmpAprLeavInput el);
    }
}