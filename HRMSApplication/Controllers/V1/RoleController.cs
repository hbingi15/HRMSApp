using HRMSApplication.Contracts;
using HRMSApplication.Identity;
using HRMSApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HRMSApplication.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> roleManager;
        ILoggerManager log = null;
        IRole ir = null;
        public RoleController(UserManager<ApplicationUser> umg, ILoggerManager log, RoleManager<IdentityRole> rm)
        {
            this._userManager = umg;
            this.log = log;
            roleManager = rm;
        }

        [HttpPost]
        [Route("Create/Role")]
        //--------------method to create a role
        public async Task<IActionResult> Create([Required] string roleName)
        {

            IdentityResult result = await roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
            {
                return Ok(roleName + "Role Created Successfully");
            }

            else
            {
                Errors(result);
                return Ok(roleName + "Role Not Created ");
            }
        }
        [HttpGet]
        [Route("AllRoles")]
        //-------------------method to get all roles 
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(roleManager.Roles);
        }

        //---------------------Delete Role By Role Name----------------------
        [HttpDelete]
        [Route("Roles/DeleteRoleByName/{rolename}")]
        public async Task<IActionResult> DeleteRoleByName([Required] string rolename)
        {

            var role = await roleManager.FindByNameAsync(rolename);
            if (role != null)
            {
                var res = await roleManager.DeleteAsync(role);
                if (!res.Succeeded)
                    return Ok(role + " could not be deleted");

                return Ok(role + " deleted Successfully");
            }
            else
            {
                return Ok("Wrong role given");
            }

        }


        [HttpPost]
        [Route("AddUserToRole")]
        //-------------------------method to add user to role
        public async Task<IActionResult> AddUserToRole(UserRole ur)
        {
            
            //Get the appln user
            ApplicationUser user = await _userManager.FindByNameAsync(ur.UserName);
            if (user != null)
            {

                if (ur.Designation == "HR Manager" || ur.Designation == "Manager")
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(user, "Admin");


                    if (result.Succeeded)
                    {
                        return Ok("Role has been added to user Successfully");

                    }
                    else
                    {
                        return Ok("Role not added to user");
                    }
                    return Ok("Role not added to user");
                }
                if (ur.Designation == "Developer" || ur.Designation == "Software Engineer" || ur.Designation == "Testing")
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(user, "Employee");


                    if (result.Succeeded)
                    {
                        return Ok("Role has been added to user Successfully");

                    }
                    else
                    {
                        return Ok("Role not added to user");
                    }
                    return Ok("Role not added to user");
                }
                return Ok("Role not added to user");
            }
            else
            {
                return Ok("Wrong User Given");
            }
        }

        [HttpDelete]
        [Route("RemoveUser")]
        //method to remove a role from user
        public async Task<IActionResult> RemoveUserFromRole([Required] string userName, [Required] string roleName)
        {
            //Get the appln user
            ApplicationUser user = await _userManager.FindByNameAsync(userName);
            IdentityResult result = await _userManager.RemoveFromRoleAsync(user, roleName);

            if (result.Succeeded)
                return Ok("Role has been removed from user Successfully");
            else
            {
                Errors(result);
                return Ok("User not removed from Role");
            }
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
