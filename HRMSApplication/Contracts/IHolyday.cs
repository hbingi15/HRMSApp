using HRMSApplication.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IHolyday
    {
        public IEnumerable<HolydayEntity> GetAllHolydays();
        public bool AddHolyday(HolydayEntity e);
        public bool EditHolyday(EditHolyday eh);
    }
}
