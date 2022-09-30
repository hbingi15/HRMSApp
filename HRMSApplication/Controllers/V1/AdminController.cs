using HRMSApplication.Contracts;
using HRMSApplication.Identity;
using HRMSApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace HRMSApplication.Controllers.v1
{
    //[Authorize(Roles = "Admin")]
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        static string securityKey = "";
        ILoggerManager log = null;
        private UserManager<ApplicationUser> _userManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        IUser iu;
        IAuthent ia;
        private RoleManager<IdentityRole> roleManager;
        IAuthent iau;
        public AdminController(ILoggerManager log, UserManager<ApplicationUser> umg, IPasswordHasher<ApplicationUser> passwordHasher, IUser iu, IAuthent ia, RoleManager<IdentityRole> roleManager,IAuthent iau)
        {
            this.log = log;
            this._userManager = umg;
            this.passwordHasher = passwordHasher;
            this.iu = iu;
            this.ia = ia;
            this.roleManager = roleManager;
            this.iau=iau;
        }
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    return Ok("Action perform successfully!");
        //}

        //-----------Create User in AspnetUsers and User Id insert into Employee Table---------
        [HttpPost]
        [Route("Create/User")]
        public async Task<IActionResult> CreateUser([FromBody] UserInput u)
        {
            try
            {
                ApplicationUser appuser = new ApplicationUser { UserName = u.UserName, FirstName = u.FirstName, LastName = u.LastName, PhoneNumber = u.PhoneNumber };


                //-----------Using Hashpassword Method---------------
                //appuser.PasswordHash = passwordHasher.HashPassword(appuser, u.Password);

                //--------------Using BCrypt Algorithm------------
                // int salt = 12;
                //appuser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(u.Password,salt);

                //---------------Assign Direct password into PasswordHash
               
                //appuser.PasswordHash = u.Password;

                //   appuser.Pa
                //
                //   sswordHash = HashPassword(u.Password);

                //appuser.PasswordHash = EncodePasswordToBase64(u.Password);

                // string depassword = Decodepassword(appuser.PasswordHash);

                IdentityResult result = await _userManager.CreateAsync(appuser, u.Password);


                if (result.Succeeded)
                {
                    bool res = iu.AddUser(u, appuser.Id);
                    return Ok("User Created successfully");
                }

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


        
        //---------------------Get All Users---------------------------
        // [AllowAnonymous]
        [HttpGet]
        [Route("AllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userManager.Users.ToList());
        }

        //---------------------Get First User----------------------
        [HttpGet]
        [Route("Firstuser")]
        public async Task<IActionResult> FirstUser()
        {
            return Ok(_userManager.Users.FirstOrDefault());
        }

        //---------------------Get User By User Name----------------------
        [HttpGet]
        [Route("UserByName")]
        public async Task<IActionResult> GetUserByName(string username)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            return Ok(user);
        }

        //---------------------Delete User By User Name----------------------
        [HttpDelete]
        [Route("Users/DeleteUserByName/{username}")]
        public async Task<IActionResult> DeleteUserByName([Required] string username)
        {

            ApplicationUser user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                    return Ok(username + " could not be deleted");

                return Ok(username + " deleted Successfully");
            }
            else
            {
                return Ok("Wrong user given");
            }

        }

        //-----------User Login---------
        [HttpPost]
        [Route("User/Login")]
        public async Task<IActionResult> AdminLogin([FromForm] AdminLogin al)
        {
            try
            {
                
                var user = _userManager.Users.SingleOrDefault(x => x.UserName == al.UserName);
                var roleNames = await _userManager.GetRolesAsync(user);

                //var roles = roleManager.Roles.ToList();


                //var user = await userManager.FindByEmailAsync(loginModel.Email);

                //var roleNames = await userManager.GetRolesAsync(user);

                var userrole = roleNames[0];
                //generate token
                var token = iau.GenerateToken(user.UserName, userrole);
               

                if (user != null && await _userManager.CheckPasswordAsync(user, al.Password))
                {
                     
                    //var token = jwtTokenManager.GenerateToken(user.UserName);
                    // return Ok(token);
                    
                    //var rolename= roleManager.Roles.SingleOrDefault(x=>x.Id == roles[0].Id);
                    //var role = await roleManager.FindByNameAsync(rolename);
                    //return Ok(user.UserName + " Login Successfully");
                    return Ok(token);
                }
                else
                {
                    return Ok("Given credentails are not valid");
                }


            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
