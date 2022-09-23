using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Contracts
{
    public interface IRole
    {
        public bool AddUserToRole(string userName,string roleName);
    }
}
