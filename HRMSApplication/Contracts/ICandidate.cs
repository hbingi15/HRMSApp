using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface ICandidate
    {
        public Task<IEnumerable<EOCandidateEntity>> GetAllCandidateOfferL();
        
    }
}
