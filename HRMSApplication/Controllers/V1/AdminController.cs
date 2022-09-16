using HRMSApplication.Contracts;
using HRMSApplication.Identity;
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
        [Route("User/Create")]
        public async Task<IActionResult> CreateUser([FromForm][Required] string userName, [Required] string firstName, [Required] string lastName, [Required] string password, [Required] string email, [Required] string phonenumber, [Required] string joindate)
        {
            try
            {
                ApplicationUser appuser = new ApplicationUser { UserName = userName, FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phonenumber };

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
