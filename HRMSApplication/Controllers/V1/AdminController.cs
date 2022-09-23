using HRMSApplication.Contracts;
using HRMSApplication.Identity;
using HRMSApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace HRMSApplication.Controllers.v1
{
    // [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        static string securityKey = "";
        ILoggerManager log = null;
        private UserManager<ApplicationUser> _userManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        IUser iu;
        public AdminController(ILoggerManager log, UserManager<ApplicationUser> umg, IPasswordHasher<ApplicationUser> passwordHasher, IUser iu)
        {
            this.log = log;
            this._userManager = umg;
            this.passwordHasher = passwordHasher;
            this.iu = iu;
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
                appuser.PasswordHash = u.Password;

                //   appuser.PasswordHash = HashPassword(u.Password);

                //appuser.PasswordHash = EncodePasswordToBase64(u.Password);

                // string depassword = Decodepassword(appuser.PasswordHash);

                IdentityResult result = await _userManager.CreateAsync(appuser, appuser.PasswordHash);


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

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        /* public string Decodepassword(string encodedData)
         {
             try
             {
                 System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                 System.Text.Decoder utf8Decode = encoder.GetDecoder();
                 byte[] todecode_byte = Convert.FromBase64String(encodedData);
                 int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                 char[] decoded_char = new char[charCount];
                 utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                 string result = new String(decoded_char);
                 return result;
             }
             catch (Exception ex)
             {
                 throw new Exception("Error in base64Encode" + ex.Message);
             }
          }*/

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
                //--------------Using BCrypt Algorithm------------
                var user = _userManager.Users.SingleOrDefault(x => x.UserName == al.UserName);
                /*bool isvalidpassword = BCrypt.Net.BCrypt.Verify(al.Password, user.PasswordHash);


               if (isvalidpassword)
               {
                  return Ok(user.UserName + " Login Successfully");
               }
               else
               {
                   return Ok("Given credentails are not valid");
               } */

                /* if (al.Password== user.PasswordHash)
                  {
                      return Ok(user.UserName + " Login Successfully");
                  }
                  else
                  {
                      return Ok("Given credentails are not valid");
                  } */

                bool res = VerifyHashedPassword(user.PasswordHash, al.Password);
                if (res == true)
                {
                    return Ok(user.UserName + " Login Successfully");
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

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }

    }
}
