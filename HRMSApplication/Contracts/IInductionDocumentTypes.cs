using HRMSApplication.Models.Entity;

namespace HRMSApplication.Contracts
{
    public interface IInductionDocumentTypes
    {
        public  Task<IEnumerable<InductionDocumentType>> GetAllInductionDocumentTypes();
    }
}
