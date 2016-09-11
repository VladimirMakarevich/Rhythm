using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Rhythm.Authentication
{
    public class AppUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class DogIdentityDbContext : IdentityDbContext<AppUser>
    {
        // EF
        public DogIdentityDbContext() : base("DogCodingIdentity", throwIfV1Schema: false) { }
        public static DogIdentityDbContext Create()
        {
            return new DogIdentityDbContext();
        }
    }
}