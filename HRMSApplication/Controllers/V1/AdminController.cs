using HRMSApplication.Contracts;
using HRMSApplication.Identity;
using HRMSApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HRMSApplication.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        static string securityKey = "";
        ILoggerManager log = null;
       private UserManager<ApplicationUser> _userManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        public AdminController(ILoggerManager log,UserManager<ApplicationUser> umg, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            this.log = log;
            this._userManager = umg;
            this.passwordHasher = passwordHasher;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok("Action perform successfully!");
        }

        [HttpPost]
        [Route("Create/User")]
        public async Task<IActionResult> CreateUser([FromForm]EmployeeEntity e)
        {
            try
            {
                ApplicationUser appuser = new ApplicationUser { FirstName = e.empl_firstname, LastName = e.empl_lastname, Email = e.empl_pemail, PhoneNumber = e.empl_mobile};

                appuser.PasswordHash = passwordHasher.HashPassword(appuser, password);

                IdentityResult result = await _userManager.CreateAsync(appuser, appuser.PasswordHash);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return Ok(result.Errors.ToString());
                }
                return Ok("User Created successfully!");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
    }
}
