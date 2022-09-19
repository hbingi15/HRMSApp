using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface ICandidate
    {
        public Task<IEnumerable<EOCandidateEntity>> GetAllCandidateOfferL();
        //public IActionResult AddEmployeeOfferLetter(ECEntity eop);
        public bool AddEmployeeOfferLetter(ECEntity e);
        public IActionResult AddCandidate(CandidatesEntity e);

    }
}
