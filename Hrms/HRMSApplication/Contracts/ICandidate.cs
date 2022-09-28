using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface ICandidate
    {
        public Task<IEnumerable<EOCandidateEntity>> GetAllCandidateOfferL();
        //public IActionResult AddEmployeeOfferLetter(ECEntity eop);
        public IEnumerable<CandidatesEntity> GetAllCandidates();
        public bool AddCandidate(CandidatesEntity e);
        public bool EditCandidate(EditCandidate c);

    }
}
