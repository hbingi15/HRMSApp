using HRMSApplication.Contracts;
using HRMSApplication.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSApplication.Repository
{
    public class RoleRepository 
    {
        private RoleManager<IdentityRole> roleManager;
        ILoggerManager log = null;
        IRole ir = null;
        private UserManager<ApplicationUser> _userManager;
        public RoleRepository(ILoggerManager log,RoleManager<IdentityRole> rm,UserManager<ApplicationUser> umg)
        {
            this.log = log;
            roleManager = rm;
            this._userManager = umg;
        }
        //public async Task<IActionResult> AddUserToRole(string userName, string roleName)
        //{
        //    //Get the appln user
        //    ApplicationUser user =  _userManager.FindByNameAsync(userName);

        //    IdentityResult result = await _userManager.AddToRoleAsync(user, roleName);

        //    if (result.Succeeded)
        //    {
        //        return Ok("");
                   
        //    }
               
        //    else
        //    {
               
        //    }
        //}
       
    }
}
