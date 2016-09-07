using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Rhythm.Authentication
{
    public class DogUserManager : UserManager<AppUser>
    {
        public DogUserManager(IUserStore<AppUser> store) : base(store) { }

        public static DogUserManager Create(IdentityFactoryOptions<DogUserManager> options, IOwinContext context)
        {
            var manager = new DogUserManager(new UserStore<AppUser>(context.Get<DogIdentityDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };
            //Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);
            manager.MaxFailedAccessAttemptsBeforeLockout = 10;

            var dataProtection = options.DataProtectionProvider;
            if (dataProtection != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(dataProtection.Create("Dog Coding Identity 23"));
            }
            return manager;
        }
    }
}