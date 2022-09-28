using HRMSApplication.Models.Entity;

namespace HRMSApplication.Contracts
{
    public interface IEmployOfferLetter
    {
        public IEnumerable<ECEntity> GetAllEmployeeOffers();
        public bool AddEmployeeOfferLetter(ECEntity e);
    }
}
