using HRMSApplication.Models.Entity;

namespace HRMSApplication.Contracts
{
    public interface IEmployeeOfferDocuments
    {
        public  Task<IEnumerable<InductionDocumentTypesEntity>> GetAllEmployeeOfferDocuments();
    }
}
