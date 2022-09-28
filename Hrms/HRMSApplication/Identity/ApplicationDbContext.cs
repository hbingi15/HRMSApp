using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMSApplication.Identity
{
    //IdentityDbContext,represents the DbContext for Identity,It has definitions for all the tables 
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
