using HRMSApplication.Models;

namespace HRMSApplication.Contracts
{
    public interface IUser
    {
        public bool AddUser(UserInput u,string id);
    }
}
