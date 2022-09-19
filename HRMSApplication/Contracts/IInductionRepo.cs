using HRMSApplication.Models;

namespace HRMSApplication.Contracts
{
    public interface IInductionRepo
    {
        public  Task<IEnumerable<InductionEntity>> AllInductions();
    }
}
