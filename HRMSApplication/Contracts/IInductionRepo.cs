using HRMSApplication.Models;

namespace HRMSApplication.Contracts
{
    public interface IInductionRepo
    {
        public IEnumerable<InductionEnitity> AllInductions();
    }
}
